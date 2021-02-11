using System.Text.Json.Serialization;

namespace Model
{
    public class PcProdut : IBaseClasses
    {
        [JsonPropertyName("CODPROD")]
        public virtual int id { get; set; } // CODPROD

        public virtual string DESCRICAO { get; set; }

        public virtual string UNIDADE { get; set; }

        public virtual string CODFAB{ get; set; }

        public virtual string EMBALAGEM{ get; set; }

        public virtual string DESCRICAO4{ get; set; }

        public virtual string DESCRICAO5{ get; set; }

        public virtual string DESCRICAO7{ get; set; }
    }
}
