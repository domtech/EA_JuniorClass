using UnityEngine;
public class UI_Login : UIBase
{

    

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnLogin()
    {

        //����loading
        var tmp = UIManager.Inst.OpenUI<UI_LoadingV2>();

        tmp.OnStart();

        UIManager.Inst.CloseUI<UI_Login>(this, true);
    }

}
