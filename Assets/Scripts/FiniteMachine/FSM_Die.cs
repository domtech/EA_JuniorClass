using UnityEngine;
using AttTypeDefine;
public class FSM_Die : FSMState
{
    public FSM_Die(NpcActor na) : base(eStateID.eDie, na) { }

    public override void OnStart()
    {
        //关闭碰撞器,不在接收碰撞
        Owner.Anim.SetTrigger("Base Layer.Die");
        Owner.CharacCtrl.enabled = false;
    }

}
