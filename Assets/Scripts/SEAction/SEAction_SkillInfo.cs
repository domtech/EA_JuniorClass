using UnityEngine;
using AttTypeDefine;
public class SEAction_SkillInfo : SEAction_BaseAction
{
    [HideInInspector]
    public eSkillBindType SkillBindType;

    [HideInInspector]
    public string ObjName;


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
            ses[i].SkillInfo = this;
        }
    }

}
