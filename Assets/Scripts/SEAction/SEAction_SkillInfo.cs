using UnityEngine;

public class SEAction_SkillInfo : MonoBehaviour
{

    public float Duration;
    float StarTime = 0f;
    void Start()
    {
        StarTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - StarTime >= Duration)
        {
            Destroy(gameObject);
        }
    }

    public void SetOwner(GameObject Owner)
    {
        SEAction_DataStore[] ses = gameObject.GetComponentsInChildren<SEAction_DataStore>();

        for(var i = 0; i < ses.Length; i++)
        {
            ses[i].Owner = Owner;
        }

    }

}
