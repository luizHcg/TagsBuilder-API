using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace DAO.Controllers
{
    public class Generics<T> where T : IBaseClasses
    {
        private readonly ISession _session;

        protected Generics(ISession session)
        {
            _session = session;
        }

        // Salva ou modifica um objeto
        public async Task<T> SaveOrUpdate(T entity)
        {
            var transaction = _session.BeginTransaction();

            try
            {
                await _session.SaveOrUpdateAsync(entity);
                await transaction.CommitAsync();
                return entity;
            }
            catch (Exception err)
            {
                if (!transaction.WasCommitted) await transaction.RollbackAsync();
                throw new Exception(err.Message);
            }
        }

        // Salva ou modifica uma lista de um determinado objeto
        public async Task<List<T>> SaveAll(List<T> list)
        {
            foreach (var item in list)
            {
                var transaction = _session.BeginTransaction();
                try
                {
                    await _session.SaveOrUpdateAsync(item);
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    if (!_session.BeginTransaction().WasCommitted) await _session.BeginTransaction().RollbackAsync();
                    _session.Close();
                    _session.Dispose();
                    throw new Exception();
                }
            }

            _session.Close();
            _session.Dispose();

            return list;
        }

        // Remove um objeto
        public async Task<bool> Delete(T entity, int id)
        {
            var transaction = _session.BeginTransaction();

            try
            {
                if (entity.id == id)
                {
                    await _session.DeleteAsync(entity);
                    await transaction.CommitAsync();
                }
                else
                {
                    throw new Exception("'ID' current not fount in class.");
                }

                return true;
            }
            catch (Exception err)
            {
                if (!transaction.WasCommitted) await transaction.RollbackAsync();
                throw new Exception(err.Message);
            }
        }

        // Busca uma lista de objetos
        public async Task<List<T>> FindAll()
        {
            return await _session.Query<T>().ToListAsync();
        }

        // Busca um objeto expecifico
        public async Task<T> FindById(int id)
        {
            return await _session.GetAsync<T>(id);
        }

        public async Task<int> CountRows()
        {
            return await _session.Query<T>().CountAsync();
        }
    }
}