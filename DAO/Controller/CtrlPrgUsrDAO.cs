using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAO.Controllers;
using Model;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Util;

namespace TagsBuilder_API.DAO.Controller {
    public class CtrlPrgUsrDAO : Generics<CtrlPrgUsr> {
        private readonly ISession _session;

        public CtrlPrgUsrDAO (ISession session) : base (session) {
            _session = session;
        }

        public async Task<CtrlPrgUsr> Authentication (int login, string password) {
            MD5 md5Hash = MD5.Create ();
            byte[] data = md5Hash.ComputeHash (Encoding.UTF8.GetBytes (password));

            StringBuilder @string = new StringBuilder ();

            for (int i = 0; i < data.Length; i++) {
                @string.Append (data[i].ToString ("x2"));
            }

            var result = await _session.Query<CtrlPrgUsr> ()
                .Where (item => item.LOGIN == login && item.SENHA == @string.ToString ().ToUpper ())
                .FirstAsync ();

            return result;

        }
    }
}