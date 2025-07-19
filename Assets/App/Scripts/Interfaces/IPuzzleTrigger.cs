
public interface IPuzzleTrigger
{
    void TriggerPuzzle();

    // bool IsSolved { get; }

    void ResetPuzzle();
    void OnPuzzleFinished();
}
