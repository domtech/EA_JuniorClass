using UnityEngine;

public class FSM_Idle : FSMState
{

    public FSM_Idle(NpcActor na) : base(na) { }

    public override void OnUpdate()
    {

        if(Vector3.Distance(Owner.transform.position, PlayerInst.transform.position) < 3f)
        {
            // SetTransition(eState.Chase);
        }
     

    }

}
