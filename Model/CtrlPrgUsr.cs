using System.Text.Json.Serialization;

namespace Model
{
    public class CtrlPrgUsr : IBaseClasses
    {

        [JsonPropertyName("SEQUSR")]
        public virtual int id { get; set; } // SEQUSR

        public virtual int CODPRG  { get; set;}

        public virtual int LOGIN { get; set; }

        public virtual int TIPO { get; set; } // 1 - Administrador, 2 - Gerente, 3 - Usuario

        public virtual string SENHA { get; set; }

        public virtual int ATIVO { get; set; }

        public virtual PcEmpr PcEmpr { get; set; }
}
}
