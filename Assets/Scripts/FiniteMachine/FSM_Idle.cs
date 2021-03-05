using UnityEngine;
using AttTypeDefine;
public class FSM_Idle : FSMState
{

    public FSM_Idle(NpcActor na) : base(eStateID.eIdle, na) { }

    public override void OnUpdate()
    {

        if(Vector3.Distance(Owner.transform.position, PlayerInst.transform.position) < 5f)
        {
            // SetTransition(eState.Chase);
            Owner.FSMInst.SetTransition(AttTypeDefine.eStateID.eChase);
            return;
        }
     

    }

}
