using System.Collections.Generic;

namespace NorthwindMvc.Models
{
  public class HomeModelBindingViewModel
  {
    public Thing Thing { get; set; }
    public bool HasErrors { get; set; }
    public IEnumerable<string> ValidationErrors { get; set; }
  }
}