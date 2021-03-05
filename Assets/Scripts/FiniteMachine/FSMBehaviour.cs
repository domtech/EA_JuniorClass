
using UnityEngine;

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


        SysInst.AddState(idle);
    }


    //我们希望游戏启动，角色能够进入idle状态

    //FSMBehaviour -> Idle State



}
