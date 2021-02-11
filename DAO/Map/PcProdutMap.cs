using FluentNHibernate.Mapping;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagsBuilder_API.DAO.Map
{
    public class PcProdutMap : ClassMap<PcProdut>
    {
        public PcProdutMap()
        {
            Table("PCPRODUT");

            Id(c => c.id).Column("CODPROD");
            Map(c => c.CODFAB);
            Map(c => c.DESCRICAO);
            Map(c => c.DESCRICAO4);
            Map(c => c.DESCRICAO5);
            Map(c => c.DESCRICAO7);
            Map(c => c.EMBALAGEM);
            Map(c => c.UNIDADE);
        }
    }
}
