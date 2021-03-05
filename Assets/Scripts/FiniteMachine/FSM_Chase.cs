
using UnityEngine;
using AttTypeDefine;
using DG.Tweening;

public class FSM_Chase : FSMState
{

    float ChaseDis;

    public FSM_Chase(NpcActor na) : base(eStateID.eChase, na) { }

    public override void OnUpdate()
    {
        ChaseDis = Vector3.Distance(Owner.transform.position, PlayerInst.transform.position);
        if (ChaseDis < (PlayerInst.PlayerRadius + Owner.PlayerRadius) * Owner.BaseAttr.AttackDis)
        {
            //NpcState = eStateID.eAttack;
            Owner.FSMInst.SetTransition(eStateID.eAttack);
            return;
        }
        //朝向
        Owner.transform.DOLookAt(PlayerInst.transform.position, 0.1f);

        //追击的速度

        Owner.transform.position += Owner.transform.forward * Owner.BaseAttr.Speed * Time.deltaTime;

        //播放追击动画
        Owner.Anim.SetFloat("Speed", 1f);
    }

    public override void OnEnd()
    {
        Owner.Anim.SetFloat("Speed", 0f);
    }

}
