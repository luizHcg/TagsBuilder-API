using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Controllers;
using Model;
using NHibernate;
using NHibernate.Linq;

namespace TagsBuilder_API.DAO.Controller {
    public class TagWatcherDAO : Generics<TagWatcher> {
        private readonly ISession _session;
        private readonly int maxPage = 20;

        public TagWatcherDAO (ISession session) : base (session) {
            _session = session;
        }

        public async Task<List<TagWatcher>> FindPage (int page) {
            var skip = page == 1 ? 0 : (maxPage - 1) * page;
            var result = await _session.Query<TagWatcher> ()
                .OrderBy (item => item.CREATE_AT)
                .Reverse ()
                .Skip (skip)
                .Take (maxPage)
                .ToListAsync ();

            return result;
        }
    }
}