using UnityEngine;
using AttTypeDefine;
using System.Collections.Generic;

public class SEAction_SkillInfo : SEAction_BaseAction
{
    [HideInInspector]
    public eSkillBindType SkillBindType;

    [HideInInspector]
    public string ObjName;

    List<GameObject> DSList;

    private void Awake()
    {
        DSList = new List<GameObject>();
    }
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
            DSList.Add(ses[i].gameObject);
        }
    }


    public void DestroyAllInst ()
    {
        while(DSList.Count > 0)
        {
            var tmp = DSList[0];
            DSList.Remove(tmp);
            Destroy(tmp);
        }
    }

    public void AddEffect(GameObject effect)
    {
        DSList.Add(effect);
    }

}
