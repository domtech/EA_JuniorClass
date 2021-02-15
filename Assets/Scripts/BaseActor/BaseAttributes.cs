using AttTypeDefine;
using com.dxz.config;
using UnityEngine;

public class BaseAttributes : MonoBehaviour
{


    private float speed;
    public float Speed =>(speed);

    private float attackdis;
    public float AttackDis => (attackdis);


    //hp, attack
    int[] attrs;

    BGE_PlayerTemplate PlayerTpl;

    BGE_PlayerAttTemplate PlayerAttTpl;

    BasePlayer Owner;

    void Awake()
    {
        attrs = new int[(int)ePlayerAttr.eSize];
    }



    //建立表格 check

    //填写表格数据 check

    //读取表格数据

    //将表格数据赋值给BaseAttributes的成员变量们


    //初始化角色的基础信息
    public void InitPlayerAttr (BasePlayer bp, string Name)
    {
      
        PlayerTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerTemplate>("PlayerTemplate", Name);
        PlayerAttTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerAttTemplate > ("PlayerAttTemplate", Name);

        Owner = bp;

        this[ePlayerAttr.eMaxHP] = PlayerAttTpl.f_MAXHP;
        this[ePlayerAttr.eAttack] = PlayerAttTpl.f_Attack;
        this[ePlayerAttr.eHP] = PlayerAttTpl.f_HP;
        speed = PlayerAttTpl.f_Speed;
        attackdis = PlayerAttTpl.f_AttackDis;

    }


    public int this[ePlayerAttr att]
    {
        get
        {

            if(att <= ePlayerAttr.eNULL)
            {
                return -1;
            }
            else
            {
                return attrs[(int)att];
            }
        }
        set
        {
            if (att <= ePlayerAttr.eNULL)
            {
                Debug.LogError("Logic Error:" + att);
                return;
            }


            if (value != attrs[(int)att])
            {
               
                if (att == ePlayerAttr.eHP && Owner.PlayerSide == ePlayerSide.eEnemy)
                {
                    if (attrs[(int)att] == 0 && value == this[ePlayerAttr.eMaxHP])
                    {
                        attrs[(int)att] = value;
                        return;
                    }

                    attrs[(int)att] = value;
                    //update player hp ui

                    float cur = (float)attrs[(int)att];

                    float hpPer = cur / this[ePlayerAttr.eMaxHP];
                    ((NpcActor)Owner).UpdateHp(hpPer);
                }
                else
                {
                    attrs[(int)att] = value;
                }

                
            }
        }
    }

   
}
