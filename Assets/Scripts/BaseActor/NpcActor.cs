using AttTypeDefine;
using UnityEngine;
public class NpcActor : BasePlayer
{
    #region Paras
    UI_HUD NpcHUD;

    [HideInInspector]
    public BasePlayer PlayerInst;

    NpcAICtrl AICtrl;
    #endregion

    #region Sys
    protected override void Awake()
    {
        base.Awake();
       
    }

    protected override void Start()
    {
        base.Start();
       
    }

    public void OnStart(AnimCtrl player)
    {
        PlayerInst = player;
        //AICtrl = gameObject.AddComponent<NpcAICtrl>();
        //AICtrl.OnStart(this);
    }

    public void Update()
    {
        NpcHUD?.SetHUDPos(this);
    }
    #endregion

    #region HUD& GetHit
    public void GetHit()
    {
        Anim.SetTrigger("Base Layer.GetHit");
    }

    public void UpdateHp (float hp)
    {
        NpcHUD?.UpdateHp(hp);
    }
    #endregion

    #region Npc AI Ctrl
    public void SetAIState(eStateID state)
    {
        if (null == AICtrl)
            return;
        AICtrl.NpcState = state;
    }
    #endregion

    #region FSMBehaviour
    private FSMBehaviour fsminst;
    public FSMBehaviour FSMInst => fsminst;
    #endregion

    #region Load Enemy
    public static NpcActor CreateNpcActor(string RoleName, BirthPoint bp)
    {

        var ret = CreateBaseActor<NpcActor>(RoleName, bp);

        ret.fsminst = ret.gameObject.AddComponent<FSMBehaviour>();
        ret.fsminst.OnStart(ret);
        //load HUD
        ret.NpcHUD = UIManager.Inst.OpenUI<UI_HUD>(true);

        //NpcActor
        return ret;
    }

    #endregion

    #region Self Destroy

    public static void DestroySelf(NpcActor actor)
    {
        Destroy(actor.NpcHUD.gameObject);
        Destroy(actor.gameObject);
    }
    #endregion


}
