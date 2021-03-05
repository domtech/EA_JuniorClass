using UnityEngine;
using AttTypeDefine;
using System.Collections;
using DG.Tweening;

public class AnimatorManager : MonoBehaviour
{

    NotifySkill SkillReadyInst;
    BasePlayer AnimInst;
    StateMachine StateInst;
    public void OnStart (BasePlayer animinst)
    {
        AnimInst = animinst;
        StateInst = AnimInst.Anim.GetBehaviour<StateMachine>();
    }

    public void StartAnimation(string AnimName, NotifySkill SkillReady, NotifySkill SkillBegin, NotifySkill SkillEnd, NotifySkill SkillEnd1)
    {
        AnimInst.Anim.SetTrigger(AnimName);


        SkillReadyInst = SkillReady;

        //clear all callbacks
        StateInst.ClearAllCallbacks();

        StateInst.RegisterCallback(eTrigSkillState.eTrigBegin, SkillBegin);

        StateInst.RegisterCallback(eTrigSkillState.eTrigEnd, ()=> {
            
            if(null != SkillEnd1)
            {
                SkillEnd1();
            }

            this.InvokeNextFrame(() =>
            {
                StateInst.RegisterCallback(eTrigSkillState.eTrigEnd, SkillEnd);
            });
        
        });

    }

    void EventSkillReady() 
    {
        SkillReadyInst();
    }


    void EventAnimBegin()
    {

    }

    void EventAnimEnd(int id)
    {
        eStateID ID = (eStateID)id;

        switch (ID)
        {
            case eStateID.eGetHit:
                {
                    if (AnimInst.PlayerSide == ePlayerSide.eEnemy)
                    {
                        StartCoroutine(WaitForAWhile());
                    }
                    break;
                }
            case eStateID.eTaunting:
                {

                    if(AnimInst.PlayerSide == ePlayerSide.eEnemy)
                    {
                        ((NpcActor)AnimInst).FSMInst.SetTransition(eStateID.eChase);
                    }

                    break;
                }
            case eStateID.eDie:
                {
                    if (AnimInst.PlayerSide == ePlayerSide.eEnemy)
                    {
                        //下沉逻辑 : 在指定的时间内，Y轴位移指定的高度
                        AnimInst.transform.DOMoveY(-0.5f, 6f).OnComplete(() =>
                        {
                            NpcActor.DestroySelf((NpcActor)AnimInst);
                            if (FightManager.Inst.LeftEnemyCount == 0)
                            {
                                FightManager.Inst.SetGameProcedure(eGameProcedure.eFightOver);
                            }
                        });
                    }
                    
                    break;
                }
        }
    }


    IEnumerator WaitForAWhile()
    {
        yield return new WaitForSeconds(0.5f);

        //NpcState = GetCurNpcAIState(eStateID.eGetHit);
        ((NpcActor)AnimInst).FSMInst.ProcessEvent(eStateID.eGetHit);
    }




}
