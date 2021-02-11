using FluentNHibernate.Mapping;
using Model;

namespace TagsBuilder_API.DAO.Map
{
    public class TagWatcherMap : ClassMap<TagWatcher>
    {
        public TagWatcherMap()
        {
            Table("TAGWATCHER");

            Id(c => c.id).Column("SEQTAGWATCHER").GeneratedBy.Sequence("SEQ_TAGWATCHER");
            
            Map(c => c.CREATE_AT);
            Map(c => c.PRODUCT_CODE);
            Map(c => c.CREATED_BY);
            Map(c => c.CREATED_NAME);
    }
    }
}
