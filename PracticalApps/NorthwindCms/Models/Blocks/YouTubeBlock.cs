using Piranha.Extend;
using Piranha.Extend.Fields;

namespace NorthwindCms.Models.Blocks
{
  [BlockType(Name = "YouTube", 
             Category = "Media", 
             Icon = "fas fa-file-video")]

  // Find icons here:
  // https://fontawesome.com/icons?d=gallery

  // I have not create an optional Vue component
  // , Component = "youtube-video-block"

  // You must add the following statement to Startup.cs:
  // App.Blocks.Register<Models.Blocks.YouTubeBlock>();

  public class YouTubeBlock : Block
  {
    /* Example of an embedded YouTube video:

    <iframe width="560" height="315" frameborder="0" allowfullscreen
      src="https://www.youtube.com/embed/D6Ac5JpCHmI?&autoplay=1&start=90">
    </iframe>

    */

    /// <summary>
    /// Gets/sets the YouTube video identifier.
    /// </summary>
    public StringField VideoID { get; set; }

    /// <summary>
    /// Gets/sets the YouTube embedded video height.
    /// </summary>
    public NumberField Height { get; set; }

    /// <summary>
    /// Gets/sets the YouTube embedded video width.
    /// </summary>
    public NumberField Width { get; set; }

    /// <summary>
    /// Gets/sets the start point for the video in seconds.
    /// </summary>
    public NumberField Start { get; set; }

    /// <summary>
    /// Gets/sets the YouTube fullscreen option.
    /// </summary>
    public CheckBoxField AllowFullscreen { get; set; }

    /// <summary>
    /// Gets/sets the YouTube autoplay option.
    /// </summary>
    public CheckBoxField Autoplay { get; set; }
  }
}