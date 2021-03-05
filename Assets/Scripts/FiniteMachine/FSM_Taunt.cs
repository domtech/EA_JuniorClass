using UnityEngine;
using AttTypeDefine;
public class FSM_Taunt : FSMState
{
    public FSM_Taunt(NpcActor na) : base(eStateID.eTaunting, na) { }

    public override void OnStart()
    {
        
        Owner.Anim.SetTrigger("Base Layer.Taunting");
    }

}
