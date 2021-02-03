using UnityEngine;
using AttTypeDefine;
public class SEAction_BaseAction : MonoBehaviour
{
    public eTrigType TrigType;
    public float Duration;
    float StarTime = 0f;
    bool IsTriggered = false;
    void Start()
    {

        if(TrigType == eTrigType.eAuto)
        {
            StarTime = Time.time;
            IsTriggered = true;
        }
    }

    public void OnStart ()
    {
        if (TrigType == eTrigType.eCondition)
        {
            StarTime = Time.time;
            IsTriggered = true;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (!IsTriggered)
            return;

        if (Time.time - StarTime >= Duration)
        {
            IsTriggered = false;
            TrigAction();
        }
    }

    public virtual void TrigAction()
    {

    }

}
