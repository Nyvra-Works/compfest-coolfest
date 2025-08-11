public interface IPoolable<T>
{
    void SetReleaseCallback(System.Action<T> releaseAction);
}