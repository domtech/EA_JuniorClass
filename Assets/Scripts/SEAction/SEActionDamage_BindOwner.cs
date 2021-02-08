using UnityEngine;
using AttTypeDefine;
using System.Collections.Generic;

public class SEActionDamage_BindOwner : SEAction_BaseAction
{
    [HideInInspector]
    public string SocketName;

    [HideInInspector]
    public Vector3 OffSet;

    [HideInInspector]
    public Vector3 OffRot;

    GameObject Owner;

    bool IsTriggered = false;

    BoxCollider BC;

    Animator Anim;

    float StartCollidePercent;
    float EndCollidePercent;

    BasePlayer bp;

    List<BasePlayer> BaList;

    private void Awake()
    {
        BaList = new List<BasePlayer>();
    }

    public override void TrigAction()
    {
        base.TrigAction();

        var ds = GetDataStore();
        if(ds == null)
        {
            Debug.LogError("Error Logic");
            return;
        }

        Owner = ds.Owner;

        //获取挂接点
        var socket = GlobalHelper.FindGOByName(Owner, SocketName);

        if (socket == null)
        {
            socket = Owner;
        }

        transform.parent = socket.transform;
        transform.localPosition = OffSet;
        transform.localRotation = Quaternion.Euler(OffRot);

        BC = GetComponent<BoxCollider>();

        Anim = Owner.GetComponent<Animator>();

        if(null == Anim)
        {
            Debug.LogError("Error Logic");
            return;
        }


        bp = Owner.GetComponent<BasePlayer>();


        var skillName = int.Parse(ds.SkillInfo.name);

        var index = skillName - bp.TypeID;

        if(index < 10)//普通攻击
        {
            StartCollidePercent = bp.AnimPerArray[index - 1].x;
            EndCollidePercent = bp.AnimPerArray[index - 1].y;
        }
        else//技能
        {
            StartCollidePercent = bp.AnimSkillPerArray[index - 1].x;
            EndCollidePercent = bp.AnimSkillPerArray[index - 1].y;
        }



        IsTriggered = true;
    }

    AnimatorStateInfo ASI;

    float curPer;
    float lastPer;
    protected override void Update()
    {
        base.Update();
        if (!IsTriggered)
            return;


        if(BaList.Count > 0)
        {
            var ba = BaList[0];
            BaList.Remove(ba);
            Debug.Log("Success : Trig Buff");
        }

        //判断是否要开启碰撞器 -> 动画进度
        ASI = Anim.GetCurrentAnimatorStateInfo(0);


        curPer = ASI.normalizedTime % 1.0f;
        if (curPer >= StartCollidePercent && lastPer < StartCollidePercent)
        {
            BC.enabled = true;
        }
        else if (curPer > EndCollidePercent && lastPer <= EndCollidePercent)
        {
            BC.enabled = false;
        }

        lastPer = curPer;
    }


    private void OnTriggerEnter(Collider other)
    {
        BasePlayer ba = other.gameObject.GetComponent<BasePlayer>();
        if(null == ba)
        {
            return;
        }
        else
        {
            //阵营问题

            var Attacker = bp;
            var Defenser = ba;

            if(
                (bp.PlayerSide == ePlayerSide.eEnemy && ba.PlayerSide == ePlayerSide.ePlayer) ||
                (bp.PlayerSide == ePlayerSide.ePlayer && ba.PlayerSide == ePlayerSide.eEnemy)
              )
            {
                // valid trigger
                BaList.Add(ba);
            }
        }
    }


}
