namespace MathGame.Services;

internal class GameTimer
{
  internal DateTime startTime {get; set;}
  internal DateTime EndTime {get; set;}
  internal void StartTimer()
  {
    startTime =  DateTime.Now;
  }

    internal void EndTimer()
  {
    EndTime =  DateTime.Now;
  }

  internal TimeSpan GetTimeSpan()
  {
    return EndTime - startTime;
  }
}