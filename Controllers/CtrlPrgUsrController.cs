using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using NHibernate;
using TagsBuilder_API.DAO.Controller;
using TagsBuilder_API.token;

namespace TagsBuilder_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CtrlPrgUsrController : ControllerBase
    {
        private readonly ISession _session;

        public CtrlPrgUsrController(ISession session)
        {
            _session = session;
        }

        [HttpPost]
        public async Task<dynamic> Post([FromBody] AuthenticationUri obj)
        {
            var result = await new CtrlPrgUsrDAO(_session).Authentication(obj.login, obj.password);
            var token = "";
            
            if (result.id != 0) {
                result.PcEmpr = await new PcEmprDAO(_session).FindById(obj.login);
                token = Token.GenerateToken(result);
            }

            return new { result, token };
        }
    }

    public class AuthenticationUri
    {
        public int login { get; set; }
        public string password { get; set; }
    }
}
