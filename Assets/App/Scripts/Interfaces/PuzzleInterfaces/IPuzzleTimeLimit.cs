public interface IPuzzleTimeLimit
{
    float PuzzleDuration { get; }
    void OnPuzzleTimeout();  
}
