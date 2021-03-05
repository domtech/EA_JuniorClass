using UnityEngine;
using AttTypeDefine;
using DG.Tweening;

public class FSM_WalkBack: FSMState
{
    public FSM_WalkBack(NpcActor na) : base(eStateID.eWalkBack, na) { }

    public float walkbackSpeed = 1f;
    public float walkbackDuration = 2f;
    public float walkbackStartTime;

    public override void OnStart()
    {
        Owner.Anim.SetTrigger("Base Layer.WalkBack");
        walkbackStartTime = Time.time;
    }

    public override void OnUpdate()
    {
        UpdateWalkBack();
    }

    void UpdateWalkBack()
    {
        if (Time.time - walkbackStartTime >= walkbackDuration)
        {
            Owner.FSMInst.SetTransition(eStateID.eChase);
            Owner.Anim.SetTrigger("Base Layer.Run");
            return;
        }
        else
        {
            Owner.transform.DOLookAt(PlayerInst.transform.position, 0.2f);

            var tmp = Owner.transform.forward;
            tmp.y = 0f;
            Owner.transform.forward = tmp;


            Owner.transform.position += (-1f) * walkbackSpeed * Time.deltaTime * Owner.transform.forward;
        }
    }

}
