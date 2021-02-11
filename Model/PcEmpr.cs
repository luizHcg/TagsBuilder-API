using System.Text.Json.Serialization;

namespace Model
{
    public class PcEmpr : IBaseClasses
    {
        [JsonPropertyName("MATRICULA")]
        public virtual int id { get; set; } // MATRICULA

        public virtual string NOME { get; set; }
    }
}
