
using System.Collections.Generic;
using AttTypeDefine;
using UnityEngine;
public class FSMSystem 
{
    public Dictionary<eStateID, FSMState> DicState;

    public FSMState CurState;

    public void OnStart ()
    {
        DicState = new Dictionary<eStateID, FSMState>();
    }

    public void AddState(FSMState state)
    {

        if(DicState.ContainsValue(state))
        {
            return;
        }
        else
        {
            if(DicState.Count == 0)
            {
                CurState = state;
            }
            DicState.Add(state.StateId, state);

        }
    }

    public void RemoveState(FSMState state)
    {
        if (DicState.ContainsValue(state))
        {
            DicState.Remove(state.StateId);
        }
    }

    public void SetTransition(eStateID id)
    {
        //新老交替
        //老 ： CurState
        //新 ： 拿到这个状态的实例对象 : Chase

        var tmpNew = DicState[id];
        if(null == tmpNew)
        {
            Debug.LogErrorFormat("Fail to transition, not find new state:({0})", id);
            return;
        }
        else
        {
            CurState = tmpNew;
        }
    }

}
