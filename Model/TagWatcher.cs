using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Model
{
    public class TagWatcher : IBaseClasses
    {
        [JsonPropertyName("SEQTAGWATCHER")]
        public virtual int id { get; set; } // SEQTAGWATCHER

        public virtual DateTime CREATE_AT { get; set; }

        public virtual string PRODUCT_CODE { get; set; } // COD. do produto ou a localização

        public virtual int CREATED_BY { get; set; } // Matricula do criador

        public virtual string CREATED_NAME { get; set; } // Nome do criador
    }
}
