using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace NorthwindCms.Models.Regions
{
    public class SiteInfo
    {
        [Field(Title = "Site Title", Options = FieldOption.HalfWidth)]
        public StringField SiteTitle { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public StringField Tagline { get; set; }

        [Field(Title = "Site Logo")]
        public ImageField SiteLogo { get; set; }
    }
}