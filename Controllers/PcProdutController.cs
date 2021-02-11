using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using NHibernate;
using TagsBuilder_API.DAO.Controller;

namespace TagsBuilder_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PcProdutController : ControllerBase
    {
        private readonly ISession _session;

        public PcProdutController(ISession session)
        {
            _session = session;
        }

        [HttpGet]
        public async Task<List<PcProdut>> Get()
        {
            return await new PcProdutDAO(_session).FindAll();
        }

        [HttpGet]
        [Route("page/{page}")]
        public async Task<dynamic> Pagination(int page)
        {
            var list = await new PcProdutDAO(_session).FindPage(page);
            var count = await new PcProdutDAO(_session).CountRows();
            return new {list, count};
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<PcProdut> One(int id)
        {            
            return await new PcProdutDAO(_session).FindById(id);            
        }

        [HttpGet]
        [Route("page/{page}/like/{whereName}/{codemaker}")]
        public async Task<dynamic> Like(int page, string whereName, int codeMaker)
        {
            var list = await new PcProdutDAO(_session).FindLike(whereName, page, codeMaker);
            var count = await new PcProdutDAO(_session).CountLikeRows(whereName, codeMaker);
            return new { list, count };
        }
    }
}
