
using UnityEngine;
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
        SysInst.AddState(idle);
        SysInst.AddState(chase);
        SysInst.AddState(attack);
    }


    public void SetTransition (eStateID id)
    {
        SysInst.SetTransition(id);
    }



}
