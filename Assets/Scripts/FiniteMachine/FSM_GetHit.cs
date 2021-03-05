using UnityEngine;
using AttTypeDefine;
using System.Collections.Generic;

public class FSM_GetHit : FSMState
{
    public int GetHitTauntPer = 1;

    public int GetHitChase = 15;

    public int GetHitWalkback = 84;
    Dictionary<int, eStateID> dicGethitPercent;
    List<int> listGethitPercent;
    void InitPercentage(out Dictionary<int, eStateID> dic, out List<int> list, int taunt, int chase, int walkback)
    {
        dic = new Dictionary<int, eStateID>();
        dic[taunt] = eStateID.eTaunting;
        dic[chase] = eStateID.eChase;
        dic[walkback] = eStateID.eWalkBack;

        var array = list = new List<int>();

        array.Add(taunt);
        array.Add(chase);
        array.Add(walkback);

        GlobalHelper.QuickSortStrict(array);


        var tmp = dic[array[2]];
        dic.Remove(array[2]);
        dic.Add(100, tmp);


        tmp = dic[array[1]];
        dic.Remove(array[1]);
        dic.Add(array[0] + array[1], tmp);


        array[2] = 100;
        array[1] = array[0] + array[1];


    }

    public FSM_GetHit(NpcActor na) : base(eStateID.eGetHit, na) { }

    public override void OnStart()
    {
        InitPercentage(out dicGethitPercent, out listGethitPercent, GetHitTauntPer, GetHitChase, GetHitWalkback);
        Owner.Anim.SetFloat("Speed", 0f);
        // play injure animation.
        Owner.Anim.SetTrigger("Base Layer.GetHit");

        Owner.transform.LookAt(PlayerInst.transform);

        var tmp = Owner.transform.forward;

        tmp.y = 0f;
        Owner.transform.forward = tmp;
    }

    public override void DoEvent(object param)
    {
        eStateID id = (eStateID)param;
        if(id == eStateID.eGetHit)
        {
            var tmp = GetCurNpcAIState();

            Owner.FSMInst.SetTransition(tmp);
        }
    }


    eStateID GetCurNpcAIState()
    {

        var percentage = Random.Range(0, 100);
        Dictionary<int, eStateID> dicPer;
        List<int> listPer;
        dicPer = dicGethitPercent;
        listPer = listGethitPercent;
    
        if (percentage < listPer[0])
        {
            return dicPer[listPer[0]];
        }
        else if (percentage >= listPer[0] && percentage < listPer[1])
        {
            return dicPer[listPer[1]];
        }
        else
        {
            return dicPer[listPer[2]];
        }
    }

}
