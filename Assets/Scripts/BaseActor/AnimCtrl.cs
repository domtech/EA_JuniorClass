using UnityEngine;
using UnityEngine.EventSystems;

public class AnimCtrl : MonoBehaviour
{

    #region Sys Funcs
    public Vector2[] AnimPerArray;
    public UI_JoyStick JoyStickInst;

    AnimatorManager AnimMgr;
    Animator _Anim;
    int _CurAnimAttackIndex = 1;
    int MinAnimAttackIndex = 1;
    int MaxAnimAttackIndex = 3;
    string CurAnimName;
    string AttackPre = "Base Layer.Attack";
    bool IsReady = true;

    EmmaKnife WeaponInst;

    bool _IsPlaying;
    public bool IsPlaying =>(_IsPlaying);

    public Animator Anim => (_Anim);
    private void Awake()
    {
        AnimMgr = gameObject.AddComponent<AnimatorManager>();
    }
    private void Start()
    {
        _Anim = GetComponent<Animator>();
        AnimMgr.OnStart(this);

        var weapongo = GlobalHelper.FindGOByName(gameObject, "greatesword");
        if(null != weapongo)
        {
            WeaponInst = weapongo.GetComponent<EmmaKnife>();
            WeaponInst.OnStart(this);
        }


        JoyStickInst.FinalSkillBtnInst.PressDown.AddListener((a) => OnFinalSkillBegin(a));
        JoyStickInst.FinalSkillBtnInst.OnDragEvent.AddListener((a) => OnFinalSkillDrag(a));
        JoyStickInst.FinalSkillBtnInst.PressUp.AddListener((a) => OnFinalSkillEnd(a));

    }
    private void Update()
    {
        UpdateSkillInput();
    }
    #endregion

    #region Cast Attack

    void UpdateSkillInput()
    {
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.K))
        {
            CastSkill();
        }
#endif
    }

    void CastSkill()
    {

        if (!IsReady)
            return;

        if(_CurAnimAttackIndex > MaxAnimAttackIndex)
        {
            _CurAnimAttackIndex = MinAnimAttackIndex;
        }

        CurAnimName = AttackPre + _CurAnimAttackIndex.ToString();
        AnimMgr.StartAnimation(CurAnimName, CastSkillReady, CastSkillBegin, CastSkillEnd, CastSkillEnd1);
    }


    void CastSkillReady()
    {
        IsReady = true;
        //Debug.Log("CastSkillReady");
    }

    void CastSkillBegin()
    {
        _IsPlaying = true;
        
        IsReady = false;

        _CurAnimAttackIndex++;

    }

    void CastSkillEnd1()
    {
       
        if(_CurAnimAttackIndex <= 1)
        {
            Debug.LogError("Logic Error");
            return;
        }

        var item = AnimPerArray[_CurAnimAttackIndex - 2];

        WeaponInst.OnStartWeaponCtrl(Anim, item.x, item.y);
    }

    void CastSkillEnd()
    {
        _CurAnimAttackIndex = MinAnimAttackIndex;
        //Debug.Log("CastSkillEnd :" + _CurAnimAttackIndex);

        IsReady = true;
        _IsPlaying = false;
    }
    //weapon ctrl 
    //

    #endregion

    #region Final Skill
    public void OnModifyFSV()
    {
        // increase angry value. -> UI, 

        JoyStickInst.OnModifyFSV();
    }

    public void OnFinalSkillBegin(PointerEventData data)
    {
        Debug.Log("OnFinalSkillBegin");
    }

    public void OnFinalSkillDrag(PointerEventData data)
    {
        Debug.Log("OnFinalSkillDrag");
    }


    public void OnFinalSkillEnd(PointerEventData data)
    {
        Debug.Log("OnFinalSkillEnd");
    }



    #endregion
}
