using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Controllers;
using Model;
using NHibernate;
using NHibernate.Linq;

namespace TagsBuilder_API.DAO.Controller {
    public class PcProdutDAO : Generics<PcProdut> {
        private readonly ISession _session;
        private readonly int maxPage = 20;

        public PcProdutDAO (ISession session) : base (session) {
            _session = session;
        }

        public async Task<List<PcProdut>> FindPage (int page) {
            var skip = page == 1 ? 0 : (maxPage - 1) * page;

            var result = await _session.Query<PcProdut> ()
                .Skip (skip)
                .Take (maxPage)
                .ToListAsync ();

            return result;
        }

        public async Task<List<PcProdut>> FindLike (string strLike, int page, int codeMaker) {
            var skip = page == 1 ? 0 : (maxPage - 1) * page;

            var result = new List<PcProdut> ();
            switch (codeMaker) {
                case 1:
                    result = await _session.Query<PcProdut> ()
                        .Where (item => item.DESCRICAO
                            .ToLower ()
                            .Like ($"%{strLike.ToLower()}%"))
                        .Skip (skip)
                        .Take (maxPage)
                        .ToListAsync ();
                    break;
                case 2:
                    result = await _session.Query<PcProdut> ()
                        .Where (item => item.CODFAB
                            .ToLower ()
                            .Like ($"%{strLike.ToLower()}%"))
                        .Skip (skip)
                        .Take (maxPage)
                        .ToListAsync ();
                    break;
                case 3:
                    result = await _session.Query<PcProdut> ()
                        .Where (item => item.id
                            .ToString ()
                            .ToLower ()
                            .Like ($"%{strLike.ToLower()}%"))
                        .Skip (skip)
                        .Take (maxPage)
                        .ToListAsync ();
                    break;
            }

            return result;
        }

        public async Task<int> CountLikeRows (string strLike, int codeMaker) {
            var result = 0;
            switch (codeMaker) {
                case 1:
                    result = await _session.Query<PcProdut> ()
                        .Where (item => item.DESCRICAO
                            .ToLower ()
                            .Like ($"%{strLike.ToLower()}%"))
                        .CountAsync ();
                    break;
                case 2:
                    result = await _session.Query<PcProdut> ()
                        .Where (item => item.CODFAB
                            .ToLower ()
                            .Like ($"%{strLike.ToLower()}%"))

                        .CountAsync ();
                    break;
                case 3:
                    result = await _session.Query<PcProdut> ()
                        .Where (item => item.id
                            .ToString ()
                            .ToLower ()
                            .Like ($"%{strLike.ToLower()}%"))
                        .CountAsync ();
                    break;
            }

            return result;
        }
    }
}