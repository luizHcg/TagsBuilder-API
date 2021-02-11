using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using NHibernate;
using TagsBuilder_API.DAO.Controller;

namespace TagsBuilder_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagWatcherController : ControllerBase
    {
        private readonly ISession _session;

        public TagWatcherController(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Procura todos os responsaveis por gerar o arquivos.
        /// </summary>
        [HttpGet]
        public async Task<List<TagWatcher>> Get()
        {
            return await new TagWatcherDAO(_session).FindAll();
        }

        /// <summary>
        /// Procura todos os responsaveis por gerar o arquivos divididos em páginas.
        /// </summary>
        /// <param name="page">página atual da aplicação</param>     
        [HttpGet]
        [Route("page/{page}")]
        public async Task<dynamic> Pagination(int page)
        {
            var list = await new TagWatcherDAO(_session).FindPage(page);
            var count = await new TagWatcherDAO(_session).CountRows();

            return new { list, count };
        }

        /// <summary>
        /// Registra o indivíduo que gerou um arquivo.
        /// </summary>
        /// <param name="tagWatcher">objeto TagWatcher</param>
        [HttpPost]
        public async Task<TagWatcher> Post([FromBody] TagWatcher tagWatcher)
        {
            tagWatcher.CREATE_AT = DateTime.Now;
            return await new TagWatcherDAO(_session).SaveOrUpdate(tagWatcher);
        }
    }
}
