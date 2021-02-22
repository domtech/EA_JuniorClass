using UnityEngine;
using UnityEngine.EventSystems;
using AttTypeDefine;
using DG.Tweening;
using System.Collections.Generic;
using com.dxz.config;

public class AnimCtrl : BasePlayer
{
    #region Sys Funcs
    List<Transform> EnemyList;

    public UI_JoyStick JoyStickInst;

    public int TYPEID = 1000;

    FinalSkillBtn FinalSkillInst;
   
    int _CurAnimAttackIndex = 1;
    int MinAnimAttackIndex = 1;
    int MaxAnimAttackIndex = 3;
    string CurAnimName;
    string AttackPre = "Base Layer.Attack";
    string SkillPre = "Base Layer.Skill";
    string SkillPrePath = "Skills/";
    bool IsReady = true;

    Camera Cam;

    bool _IsPlaying;
    public bool IsPlaying =>(_IsPlaying);

    eSkillType SkillType;


    SEAction_SkillInfo SkillInfo;
    protected override void Awake()
    {
        base.Awake();
       
        EnemyList = new List<Transform>();
    }

    protected override void Start()
    {
        base.Start();

        //todo
        //TypeId = TYPEID;

        //AnimMgr.OnStart(this);

        //FinalSkillInst = JoyStickInst.FinalSkillBtnInst;

        //Cam = Camera.main;

        //JoyStickInst.FinalSkillBtnInst.PressDown.AddListener((a) => OnFinalSkillBegin(a));
        //JoyStickInst.FinalSkillBtnInst.OnDragEvent.AddListener((a) => OnFinalSkillDrag(a));
        //JoyStickInst.FinalSkillBtnInst.PressUp.AddListener((a) => OnFinalSkillEnd(a));

        //LoadFinalSkillArrow();

    }
    private void Update()
    {
        //todo
        //UpdateSkillInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        var bp = other.gameObject.GetComponent<BasePlayer>();
        if (null == bp || bp.PlayerSide == ePlayerSide.ePlayer)
            return;

        EnemyList.Add(bp.transform);
      
    }

    private void OnTriggerExit(Collider other)
    {
        var bp = other.gameObject.GetComponent<BasePlayer>();
        if (null == bp)
            return;

        EnemyList.Remove(bp.transform);
       
    }
    #endregion

    #region Cast Attack
    void UpdateSkillInput()
    {
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.K))
        {
            CastSkill(eSkillType.eAttack);
        }
#endif
    }

    void CastSkill(eSkillType type)
    {

        if (!IsReady || IsGetHit)
            return;

        SkillType = type;

        if (type == eSkillType.eSkill1)
        {
            CurAnimName = SkillPre + ((int)SkillType).ToString();
        }
        else if(type == eSkillType.eAttack)
        {
            if (_CurAnimAttackIndex > MaxAnimAttackIndex)
            {
                _CurAnimAttackIndex = MinAnimAttackIndex;
            }

            CurAnimName = AttackPre + _CurAnimAttackIndex.ToString();
        }

        AnimMgr.StartAnimation(CurAnimName, CastSkillReady, CastSkillBegin, CastSkillEnd, CastSkillEnd1);
    }

    void CastSkillReady()
    {
        if (SkillType == eSkillType.eAttack)
            IsReady = true;
    }

    void CastSkillBegin()
    {
        _IsPlaying = true;
        
        if(SkillType == eSkillType.eAttack)
        {
            IsReady = false;


            //�泯����
            var Target = GlobalHelper.GetNearestTrans(EnemyList, transform);
            if(null != Target)
            {
                //var toward = (Target.position - transform.position).normalized;
                //toward.y = 0f;
                transform.DOLookAt(Target.position, 0.1f);
            }

            //������Ч

            // �����ƶ� �� ��Ķ�����κ������Ч����һ�� ����ô֪������a��������ȥ����a��Ч�أ�
            //1001

            var path = SkillPrePath + (1000 + _CurAnimAttackIndex).ToString();
            var SkillPrefab = GlobalHelper.InstantiateMyPrefab(path, transform.position + Vector3.up * 1f, Quaternion.identity);

            SkillInfo = SkillPrefab.GetComponent<SEAction_SkillInfo>();
            SkillInfo.SetOwner(gameObject);

            _CurAnimAttackIndex++;
        }

    }

    void CastSkillEnd1()
    {
    }

    void CastSkillEnd()
    {
        if(SkillType == eSkillType.eAttack)
        {
            _CurAnimAttackIndex = MinAnimAttackIndex;
            IsReady = true;
          
        }
        else if(SkillType == eSkillType.eSkill1)
        {
          
        }

        var state = Anim.GetCurrentAnimatorStateInfo(0);
        if(state.IsName("Base Layer.GetHit"))
        {
            Debug.Log("1");
        }
        else
        {
            _IsPlaying = false;
        }
      
    }
    #endregion

    #region Final Skill
    bool IsUsingAbility = false;
    bool IsFinishFinalSkill = false;
    Vector3 FinalSkillDir;

    public float FinalSkillDis = 1f;

    public void OnModifyFSV(int value)
    {
        JoyStickInst.OnModifyFSV(value);
    }

    public void OnFinalSkillBegin(PointerEventData data)
    {

        if (IsUsingAbility == true)
            return;


        IsFinishFinalSkill = true;

        IsUsingAbility = true;

        Time.timeScale = 0.1f;

        _GroundArrow.SetActive(true);


        var dir = FinalSkillInst.Dir.x * Cam.transform.right + FinalSkillInst.Dir.y * Cam.transform.forward;

        dir.y = 0f;

        if(dir == Vector3.zero)
        {
            dir = transform.forward;
        }

        _GroundArrow.transform.forward = dir;

    }

    public void OnFinalSkillDrag(PointerEventData data)
    {

        if (!IsFinishFinalSkill)
            return;

        FinalSkillDir = FinalSkillInst.Dir.x * Cam.transform.right + FinalSkillInst.Dir.y * Cam.transform.forward;

        if (FinalSkillDir == Vector3.zero)
        {
            FinalSkillDir = transform.forward;
        }
        else
        {
            FinalSkillDir.y = 0f;
        }

        _GroundArrow.transform.forward = FinalSkillDir;
    }


    public void OnFinalSkillEnd(PointerEventData data)
    {

        if (!IsFinishFinalSkill)
            return;

        Time.timeScale = 1f;
        _GroundArrow.SetActive(false);
        FinalSkillDir = Vector3.zero;

        OnModifyFSV(-100);

        //���ż��ܶ���
        CastSkill(eSkillType.eSkill1);

        var FinalPos = transform.position + _GroundArrow.transform.forward * FinalSkillDis;
        transform.DOMove(FinalPos, 0.7f).OnComplete(()=> {
            IsUsingAbility = false;
            IsFinishFinalSkill = false;
        });

        transform.DOLookAt(FinalPos, 0.35f);
    }
    #endregion

    #region Load Arrow
    private GameObject _GroundArrow;
    public GameObject GroundArrow => (_GroundArrow);
    void LoadFinalSkillArrow()
    {
        var obj = Resources.Load("Weapons/GrounArrow");

        _GroundArrow = Instantiate(obj, transform.position, transform.rotation) as GameObject;

        _GroundArrow.transform.parent = transform;

        _GroundArrow.transform.localPosition = Vector3.zero;
        _GroundArrow.transform.localRotation = Quaternion.identity;
        _GroundArrow.transform.localScale = Vector3.one;

        _GroundArrow.SetActive(false);

    }
    #endregion

    #region Enemy Die
    public void EnemyDie(Transform enemy)
    {
        if(EnemyList.Contains(enemy))
        {
            EnemyList.Remove(enemy);
        }
    }
    #endregion

    #region Player GetHit
    bool IsGetHit = false;
    public void PlayerGetHit()
    {

        //��һ�����Ƿ��ڲ��Ź�������

        if (Anim.IsInTransition(0))
            return;

        //��������ں��ڼ� -> ��ȥ�������˶���������Ѫ������

        //����������ں��ڼ� && �ڲ��Ź������� -> �ǿ����ն˵�

        //�ҵĹ����������жϣ������˺������Ѿ�������ʱ��
        //��ǰ�Ƿ��м��ܴ��ڣ�����У���ô��������
        //1 �� ��Ч
        //2 �� �˺����

        if(null != SkillInfo)
        {
            SkillInfo.DestroyAllInst();
        }

        IsReady = true;
        _IsPlaying = true;
        IsGetHit = true;
        Anim.SetTrigger("Base Layer.GetHit");
    }

    #endregion

    #region animation callback
    void EventAnimEnd(int id)
    {
        eStateID ID = (eStateID)id;

        switch(ID)
        {
            case eStateID.eGetHit:
                {
                    _IsPlaying = false;
                    IsGetHit = false;
                    break;
                }
        }
    }
    #endregion

    #region Create Player Actor
    public static AnimCtrl CreatePlayerActor (string RoleName, BirthPoint bp)
    {

        BGE_PlayerTemplate PlayerTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerTemplate>("PlayerTemplate", RoleName);

        BGE_PlayerAttTemplate PlayerAttTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerAttTemplate>("PlayerAttTemplate", RoleName);
        //����ģ��

        var tmp = Resources.Load(PlayerTpl.f_ModelPath);

        var actor = Instantiate(tmp, bp.transform.position, bp.transform.rotation) as GameObject;

        //���ؽű�

        var ret = actor.AddComponent<AnimCtrl>();

        //��ʼ����������

        ret.PlayerName = RoleName;

        ret.TypeId = PlayerTpl.f_TypeID;

        ret.FinalSkillDis = PlayerAttTpl.f_FinalSkillDis;

        ret.AnimPerArray = PlayerAttTpl.f_AnimPerArray.ToArray();

        ret.AnimSkillPerArray = PlayerAttTpl.f_AnimPerSkillArray.ToArray();

        //����AnimCtrl
        return ret;
    }
    #endregion

}
