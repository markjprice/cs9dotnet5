using static System.Console;

namespace Packt.Shared
{
  public interface IPlayable
  {
    void Play();

    void Pause();

    // Default interface implementation
    void Stop()
    {
      WriteLine("Default implementation of Stop.");
    }
  }
}