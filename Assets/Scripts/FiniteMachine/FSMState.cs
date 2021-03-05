
public abstract class FSMState 
{

    protected NpcActor Owner;
    protected BasePlayer PlayerInst;
    public FSMState(NpcActor na)
    {
        Owner = na;
        PlayerInst = Owner.PlayerInst;
    }

   public virtual void OnUpdate()
    {

    }
}
