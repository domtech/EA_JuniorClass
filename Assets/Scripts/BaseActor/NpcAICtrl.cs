using UnityEngine;
using AttTypeDefine;
using DG.Tweening;
public class NpcAICtrl : MonoBehaviour
{

    eStateID npcState = eStateID.eNULL;
    public eStateID NpcState
    {
        get
        {
            return npcState;
        }
        set
        {
            if (value == eStateID.eGetHit)
            {
                Owner.Anim.SetFloat("Speed", 0f);
                // play injure animation.
                Owner.Anim.SetTrigger("Base Layer.GetHit");
                //injure play is over, set state to chase.
            }
            else
            {
                if(value != npcState)
                {
                    if(value != eStateID.eChase)
                    {
                        Owner.Anim.SetFloat("Speed", 0f);
                    }

                    switch(value) {
                        case eStateID.eAttack:
                            {
                                AnimMgr.StartAnimation("Base Layer.Attack1", null, CastSkillBegin, CastSkillEnd, null);
                                break;
                            }
                    }
                }
            }
            npcState = value;
        }
    }

    void CastSkillBegin()
    {
       
    }

    void CastSkillEnd()
    {
  
        if (NpcState == eStateID.eGetHit)
            return;

        NpcState = eStateID.eChase;
    }

    bool IsTrigger = false;

    NpcActor Owner;

    BasePlayer PlayerInst;

    float ChaseDis;

    AnimatorManager AnimMgr;

    public void OnStart (NpcActor NA)
    {
        Owner = NA;
        IsTrigger = true;
        PlayerInst = Owner.PlayerInst;
        NpcState = eStateID.eChase;
        AnimMgr = gameObject.GetComponent<AnimatorManager>();
        AnimMgr.OnStart(Owner);
    }

    
    private void Update()
    {
        if (!IsTrigger)
            return;

        switch(NpcState)
        {
         
            case eStateID.eChase:
                {
                    //判断二者的距离， 如果小于某一个数值，那么就执行攻击操作

                    ChaseDis = Vector3.Distance(transform.position, PlayerInst.transform.position);
                    if(ChaseDis < (PlayerInst.PlayerRadius + Owner.PlayerRadius) * Owner.BaseAttr.AttackDis)
                    {
                        NpcState = eStateID.eAttack;
                        return;
                    }
                    //朝向
                    transform.DOLookAt(PlayerInst.transform.position, 0.1f);

                    //追击的速度

                    transform.position += transform.forward * Owner.BaseAttr.Speed * Time.deltaTime;

                    //播放追击动画
                    Owner.Anim.SetFloat("Speed", 1f);

                    break;
                }
        }
    }



    void EventAnimBegin()
    {

    }


    void EventAnimEnd(int id)
    {
        eStateID ID = (eStateID)id;

        switch(ID)
        {
            case eStateID.eGetHit:
                {
                    NpcState = eStateID.eChase;
                    break;
                }
        }
    }



}
