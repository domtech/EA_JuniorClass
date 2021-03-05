
using UnityEngine;
using AttTypeDefine;
public class FSM_Chase : FSMState
{
    public FSM_Chase(NpcActor na) : base(eStateID.eChase, na) { }

    public override void OnUpdate()
    {
        Debug.Log(1);
    }
}
