using UnityEngine;

public class SEAction_BaseAction : MonoBehaviour
{
    public float Duration;
    float StarTime = 0f;
    bool IsTriggered;
    void Start()
    {
        IsTriggered = false;
        StarTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - StarTime >= Duration && !IsTriggered)
        {
            IsTriggered = true;
            TrigAction();
        }
    }

    public virtual void TrigAction()
    {

    }

}
