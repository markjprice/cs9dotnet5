using System.Collections.Generic;

namespace NorthwindML.Models
{
  public class HomeCartViewModel
  {
    public Cart Cart { get; set; }
    public List<EnrichedRecommendation> Recommendations { get; set; }
  }
}