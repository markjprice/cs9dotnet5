using Piranha.Extend;
using Piranha.Extend.Fields;

namespace NorthwindCms.Models.Regions
{
    public class Hero
    {
        [Field(Title = "Primary image")]
        public ImageField PrimaryImage { get; set; }

        [Field]
        public HtmlField Ingress { get; set; }
    }
}