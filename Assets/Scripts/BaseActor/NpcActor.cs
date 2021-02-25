using AttTypeDefine;
using com.dxz.config;
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
        AICtrl = gameObject.AddComponent<NpcAICtrl>();
        AICtrl.OnStart(this);
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
        AICtrl.NpcState = state;
    }

    #endregion

    #region Load Enemy
    public static NpcActor CreateNpcActor(string RoleName, BirthPoint bp)
    {

        BGE_PlayerTemplate PlayerTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerTemplate>("PlayerTemplate", RoleName);

        BGE_PlayerAttTemplate PlayerAttTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerAttTemplate>("PlayerAttTemplate", RoleName);
        //加载模型

        var tmp = Resources.Load(PlayerTpl.f_ModelPath);

        var actor = Instantiate(tmp, bp.transform.position, bp.transform.rotation) as GameObject;

        actor.name = tmp.name;

        //加载脚本

        var ret = actor.AddComponent<NpcActor>();

        //初始化所有数据
        ret.PlayerName = RoleName;

        ret.TypeId = PlayerTpl.f_TypeID;

        if(null != PlayerAttTpl.f_AnimPerArray)
            ret.AnimPerArray = PlayerAttTpl.f_AnimPerArray.ToArray();

        if (null != PlayerAttTpl.f_AnimPerSkillArray)
            ret.AnimSkillPerArray = PlayerAttTpl.f_AnimPerSkillArray.ToArray();

        ret.PlayerTpl = PlayerTpl;

        ret.PlayerAttTpl = PlayerAttTpl;

        ret.PlayerSide = (ePlayerSide)PlayerTpl.f_PlayerSide;

        //load HUD
        ret.NpcHUD = UIManager.Inst.OpenUI<UI_HUD>();

        //load animator
        ret.Anim.runtimeAnimatorController = Instantiate(Resources.Load("AnimatorController/" + PlayerTpl.f_AnimCtrlPath)) as RuntimeAnimatorController;


        ret.transform.localScale = Vector3.one * bp.Scale;

        //NpcActor
        return ret;
    }

    #endregion
}
