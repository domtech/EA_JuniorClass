using AttTypeDefine;
using com.dxz.config;
using UnityEngine;

public class BaseAttributes : MonoBehaviour
{

    //hp, attack
    int[] attrs;

    BGE_PlayerTemplate PlayerTpl;

    BGE_PlayerAttTemplate PlayerAttTpl;

    void Awake()
    {
        attrs = new int[(int)ePlayerAttr.eSize];
    }

    private void Start()
    {
       
    }



    //建立表格 check

    //填写表格数据 check

    //读取表格数据

    //将表格数据赋值给BaseAttributes的成员变量们


    //初始化角色的基础信息
    public void InitPlayerAttr (string Name)
    {
      
        PlayerTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerTemplate>("PlayerTemplate", Name);
        PlayerAttTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerAttTemplate > ("PlayerAttTemplate", Name);

        this[ePlayerAttr.eAttack] = PlayerAttTpl.f_Attack;
        this[ePlayerAttr.eHP] = PlayerAttTpl.f_HP;
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
                attrs[(int)att] = value;
            }
        }
    }

   
}
