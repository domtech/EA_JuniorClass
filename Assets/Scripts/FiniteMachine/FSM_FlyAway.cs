using UnityEngine;
using AttTypeDefine;
using DG.Tweening;

public class FSM_FlyAway : FSMState
{
    public float hitBackDuration = 0.25f;
    public float hitBackDis = 2.5f;
    public FSM_FlyAway(NpcActor na) : base(eStateID.eFlyAway, na) { }

    public override void OnStart()
    {
        Owner.Anim.SetTrigger("Base Layer.HitBack");

        //位移
        var finalPos = Owner.transform.position + Quaternion.AngleAxis(180f, Vector3.up) * Owner.transform.forward * hitBackDis;

        GlobalHelper.TransLookAt2D(Owner.transform, PlayerInst.transform);
        Owner.transform.DOMove(finalPos, hitBackDuration).OnComplete(() => {
            Owner.FSMInst.SetTransition(eStateID.eChase);
            Owner.Anim.SetTrigger("Base Layer.Run");
        });
    }

}
