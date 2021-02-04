using UnityEngine;
using AttTypeDefine;
public class SEAction_BaseAction : MonoBehaviour
{
    [HideInInspector]
    public eTrigType TrigType;
    [HideInInspector]
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
    protected virtual void Update()
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

    public SEAction_DataStore GetDataStore ()
    {
        var ds = gameObject.GetComponent<SEAction_DataStore>();
        return ds;
    }

}
