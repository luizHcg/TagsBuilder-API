using FluentNHibernate.Mapping;
using Model;

namespace TagsBuilder_API.DAO.Map
{
    public class CtrlPrgUsrMap : ClassMap<CtrlPrgUsr>
    {
        public CtrlPrgUsrMap()
        {
            Table("CTRLPRG_USR");

            Id(c => c.id).Column("SEQUSR");
            Map(c => c.CODPRG);
            Map(c => c.ATIVO);
            Map(c => c.LOGIN);
            Map(c => c.SENHA);
            Map(c => c.TIPO);
        }
    }
}
