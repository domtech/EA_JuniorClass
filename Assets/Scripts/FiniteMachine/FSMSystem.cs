
using System.Collections.Generic;

public class FSMSystem 
{
    public List<FSMState> ListState;

    public FSMState CurState;

    public void OnStart ()
    {
        ListState = new List<FSMState>();
    }

    public void AddState(FSMState state)
    {
        if(ListState.Contains(state))
        {
            return;
        }
        else
        {
            if(ListState.Count == 0)
            {
                CurState = state;
            }

            ListState.Add(state);
        }
    }

    public void RemoveState(FSMState state)
    {
        if (ListState.Contains(state))
        {
            ListState.Remove(state);
        }
    }
}
