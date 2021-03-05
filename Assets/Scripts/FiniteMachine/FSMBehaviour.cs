﻿using UnityEngine;
using AttTypeDefine;
public class FSMBehaviour : MonoBehaviour
{
    FSMSystem SysInst;
    NpcActor Owner;

    public void OnStart (NpcActor na)
    {
        Owner = na;
        (SysInst = new FSMSystem()).OnStart();
        InitFSM();
    }


    private void Update()
    {
        if(null != SysInst && null != SysInst.CurState)
        {
            //驱动这个state
            SysInst.CurState.OnUpdate();
        }
    }


    void InitFSM()
    {
        var idle = new FSM_Idle(Owner);
        var chase = new FSM_Chase(Owner);
        var attack = new FSM_Attack(Owner);
        var taunt = new FSM_Taunt(Owner);
        var walkback = new FSM_WalkBack(Owner);
        var gethit = new FSM_GetHit(Owner);
        var flyaway = new FSM_FlyAway(Owner);
        var die = new FSM_Die(Owner);
        var victory = new FSM_Victory(Owner);
        SysInst.AddState(idle);
        SysInst.AddState(chase);
        SysInst.AddState(attack);
        SysInst.AddState(taunt);
        SysInst.AddState(walkback);
        SysInst.AddState(gethit);
        SysInst.AddState(flyaway);
        SysInst.AddState(die);
        SysInst.AddState(victory);

    }

    public bool IsInState (eStateID id)
    {
        return id == SysInst.CurState.StateId;
    }


    public void SetTransition (eStateID id)
    {
        SysInst.SetTransition(id);
    }


    public void ProcessEvent(object param)
    {
        SysInst.CurState.DoEvent(param);
    }
         


}
