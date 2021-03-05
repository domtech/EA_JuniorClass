using UnityEngine;
using AttTypeDefine;
public class FSM_Victory : FSMState
{
    public FSM_Victory(NpcActor na) : base(eStateID.eVictory, na) { }

    public override void OnStart()
    {
        Owner.Anim.SetTrigger("Base Layer.Victory");
    }

}
