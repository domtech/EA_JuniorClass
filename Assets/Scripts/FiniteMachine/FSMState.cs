﻿using AttTypeDefine;
public abstract class FSMState 
{
    private eStateID stateid;
    public eStateID StateId => stateid;
    protected NpcActor Owner;
    protected BasePlayer PlayerInst;
    public FSMState(eStateID id,  NpcActor na)
    {
        Owner = na;
        stateid = id;
        PlayerInst = Owner.PlayerInst;
    }

   public virtual void OnUpdate()
    {

    }
}
