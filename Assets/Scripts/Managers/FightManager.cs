using UnityEngine;

public class FightManager : MonoBehaviour
{

    /*
     * (1) : UI_Login check
     * 
     * (2) : ������Ϸ : ���Զ��������أ���UI_Login
     * 
     * ���UI_Login�ĵ�¼��ť -> ���ؽ�ɫ�Ͷ�Ӧ�Ľ�ɫUI
     * 
     * */


    UI_Login UILoginInst;
    //�������ǵ�Login UI
    private void Start()
    {
        //����login
        //var login = Instantiate(Resources.Load("UI/UI_Login")) as GameObject;

        //UILoginInst = login.GetComponent<UI_Login>();

        UILoginInst = UIManager.Inst.OpenUI<UI_Login>();
    }

    
}
