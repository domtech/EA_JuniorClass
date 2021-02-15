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
                    //�ж϶��ߵľ��룬 ���С��ĳһ����ֵ����ô��ִ�й�������

                    ChaseDis = Vector3.Distance(transform.position, PlayerInst.transform.position);
                    if(ChaseDis < (PlayerInst.PlayerRadius + Owner.PlayerRadius) * Owner.BaseAttr.AttackDis)
                    {
                        NpcState = eStateID.eAttack;
                        return;
                    }
                    //����
                    transform.DOLookAt(PlayerInst.transform.position, 0.1f);

                    //׷�����ٶ�

                    transform.position += transform.forward * Owner.BaseAttr.Speed * Time.deltaTime;

                    //����׷������
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
