using UnityEngine;

public class FightManager : MonoBehaviour
{

    CamManager CamMgr;
    private void Awake()
    {
        var GOCam = Instantiate(Resources.Load("Maps/Cams")) as GameObject;
        CamMgr = GOCam.GetComponent<CamManager>();
         
    }

    /*
     * (1) : UI_Login check
     * 
     * (2) : ������Ϸ : ���Զ��������أ���UI_Login
     * 
     * ���UI_Login�ĵ�¼��ť -> ���ؽ�ɫ�Ͷ�Ӧ�Ľ�ɫUI
     * 
     * */

    public BirthPoint BP;

    public BirthPoint EnemyBP;

    UI_Login UILoginInst;
    //�������ǵ�Login UI
    private void Start()
    {
        //����login
        //var login = Instantiate(Resources.Load("UI/UI_Login")) as GameObject;

        //UILoginInst = login.GetComponent<UI_Login>();

        UILoginInst = UIManager.Inst.OpenUI<UI_Login>();

        UILoginInst.OnStart(BP, EnemyBP, CamMgr);
    }

    
}
