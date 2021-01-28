using UnityEngine;
using AttTypeDefine;
using System.Collections.Generic;

public class StateMachine : StateMachineBehaviour
{

    bool IsLastTransition;
    bool IsCurTransition;
    AnimatorStateInfo LastStateInfo;
    Dictionary<eTrigSkillState, List<NotifySkill>> SkillDic = new Dictionary<eTrigSkillState, List<NotifySkill>>();

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        IsCurTransition = animator.IsInTransition(layerIndex);


        if(!IsCurTransition)
        {
            if(stateInfo.normalizedTime % 1.0 < LastStateInfo.normalizedTime %1.0f)
            {
                //CastSkillEnd
                TrigAction(eTrigSkillState.eTrigEnd);
            }
        }


        if(IsCurTransition && !IsLastTransition)//当前在融合 && 上一帧没有在融合
        {
            //CastSkillBegin
            TrigAction(eTrigSkillState.eTrigBegin);
        }

        if(!IsCurTransition && IsLastTransition)
        {
            //CastSkillEnd1
            TrigAction(eTrigSkillState.eTrigEnd);
        }

        IsLastTransition = IsCurTransition;
        LastStateInfo = stateInfo;

    }

    void TrigAction(eTrigSkillState state)
    {
        if(SkillDic.ContainsKey(state))
        {
            var list = SkillDic[state];
            while(list.Count > 0)
            {
                var ns = list[0];
                list.Remove(ns);
                ns();
            }
        }
    }


    public void RegisterCallback(eTrigSkillState state, NotifySkill action)
    {

        List<NotifySkill> list;
        if(SkillDic.ContainsKey(state))
        {
            list = SkillDic[state];
            list.Add(action);
        }
        else
        {
            list = new List<NotifySkill>();
            list.Add(action);
            SkillDic.Add(state, list);
        }

    }

    public void ClearAllCallbacks()
    {
        if (null == SkillDic)
            return;

        List<NotifySkill> list;
        for(var i= eTrigSkillState.eTrigBegin; i<= eTrigSkillState.eTrigEnd; i++)
        {
            if(SkillDic.ContainsKey(i))
            {
                list = SkillDic[i];
                list.Clear();
            }
        }
    }
   
}
