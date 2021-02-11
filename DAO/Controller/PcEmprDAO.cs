using DAO.Controllers;
using Model;
using NHibernate;

namespace TagsBuilder_API.DAO.Controller
{
    public class PcEmprDAO : Generics<PcEmpr>
    {
        public PcEmprDAO(ISession session) : base(session)
        {
        }
    }
}
