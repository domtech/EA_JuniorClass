
using UnityEngine;
using AttTypeDefine;
public class FSM_Attack : FSMState
{
    public FSM_Attack(NpcActor na) : base(eStateID.eAttack, na) { }


    public override void OnStart()
    {
        Debug.Log("Attack:OnStart");
    }




}
