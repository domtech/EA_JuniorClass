using UnityEngine;
using AttTypeDefine;
public class AnimatorManager : MonoBehaviour
{

    NotifySkill SkillReadyInst;
    AnimCtrl AnimInst;
    StateMachine StateInst;
    public void OnStart (AnimCtrl animinst)
    {
        AnimInst = animinst;
        StateInst = AnimInst.Anim.GetBehaviour<StateMachine>();
    }

    public void StartAnimation(string AnimName, NotifySkill SkillReady, NotifySkill SkillBegin, NotifySkill SkillEnd)
    {
        AnimInst.Anim.SetTrigger(AnimName);


        SkillReadyInst = SkillReady;

        //clear all callbacks
        StateInst.ClearAllCallbacks();

        StateInst.RegisterCallback(eTrigSkillState.eTrigBegin, SkillBegin);

        StateInst.RegisterCallback(eTrigSkillState.eTrigEnd, ()=> {

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

}
