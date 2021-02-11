using FluentNHibernate.Mapping;
using Model;

namespace TagsBuilder_API.DAO.Map
{
    public class PcEmprMap : ClassMap<PcEmpr>
    {
        public PcEmprMap() {
            Table("PCEMPR");

            Id(c => c.id).Column("MATRICULA");
            Map(c => c.NOME);
       }
    }
}
