
using UnityEngine;
using AttTypeDefine;
using DG.Tweening;
using System.Collections.Generic;

public class FSM_Attack : FSMState
{
    public FSM_Attack(NpcActor na) : base(eStateID.eAttack, na) { }

    Dictionary<int, eStateID> dicAttackPercent;
    List<int> listAttackPercent;
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

    eStateID GetCurNpcAIState()
    {

        var percentage = Random.Range(0, 100);
        Dictionary<int, eStateID> dicPer;
        List<int> listPer;
        dicPer = dicAttackPercent;
        listPer = listAttackPercent;

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

    public int AttackTauntPer = 40;

    public int AttackChase = 10;

    public int AttackWalkback = 50;

    public override void OnStart()
    {
        InitPercentage(out dicAttackPercent, out listAttackPercent, AttackTauntPer, AttackChase, AttackWalkback);

        Owner.AnimMgrInst.StartAnimation("Base Layer.Attack1", null, CastSkillBegin, CastSkillEnd, null);
    }

    void CastSkillBegin()
    {
        //面朝敌人
        var Target = PlayerInst.transform;
        if (null != Target)
        {
            //var toward = (Target.position - transform.position).normalized;
            //toward.y = 0f;
            Owner.transform.DOLookAt(Target.position, 0.1f);
        }

        var path = "Skills/2001"; 
        var SkillPrefab = GlobalHelper.InstantiateMyPrefab(path, Owner.transform.position + Vector3.up * 1f, Quaternion.identity);

        var SkillInfo = SkillPrefab.GetComponent<SEAction_SkillInfo>();
        SkillInfo.SetOwner(Owner.gameObject);

    }

    void CastSkillEnd()
    {
        var tmp = GetCurNpcAIState();        
        Owner.FSMInst.SetTransition(tmp);
    }




}
