public class IWaitForFrames : IWait
{
    float _Frames;

    public IWaitForFrames(int frames)
    {
        _Frames = frames;
    }

    public bool Tick()
    {
        _Frames -= 1;
        return _Frames < 0;
    }
}
