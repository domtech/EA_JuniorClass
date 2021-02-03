using UnityEngine;

public class SEAction_SkillInfo : SEAction_BaseAction
{
    public override void TrigAction()
    {
        Destroy(gameObject);
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
