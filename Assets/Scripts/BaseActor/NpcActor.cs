using AttTypeDefine;
public class NpcActor : BasePlayer
{

    public UI_HUD NpcHUD;

    NpcAICtrl AICtrl;



    protected override void Awake()
    {
        base.Awake();
        AICtrl = gameObject.AddComponent<NpcAICtrl>();
    }

    protected override void Start()
    {
        base.Start();
        AICtrl.OnStart(this);
    }

    public void GetHit()
    {
        Anim.SetTrigger("Base Layer.GetHit");
    }

    public void Update()
    {
        NpcHUD.SetHUDPos(this);
    }

    public void UpdateHp (float hp)
    {
        NpcHUD.UpdateHp(hp);
    }

    #region Npc AI Ctrl

    public void SetAIState(eStateID state)
    {
        AICtrl.NpcState = state;
    }

    #endregion

}
