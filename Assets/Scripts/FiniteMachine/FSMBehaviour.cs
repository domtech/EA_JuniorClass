
using UnityEngine;

public class FSMBehaviour : MonoBehaviour
{
    FSMSystem SysInst;

    private void Awake()
    {
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
        var idle = new FSM_Idle();


        SysInst.AddState(idle);
    }


    //我们希望游戏启动，角色能够进入idle状态

    //FSMBehaviour -> Idle State



}
