using UnityEngine;

public class IWaitForSeconds : IWait
{
    float _Seconds;

    public IWaitForSeconds (float seconds)
    {
        _Seconds = seconds;
    }

    public bool Tick()
    {
        _Seconds -= Time.deltaTime;
        return _Seconds < 0f;
    } 
}
