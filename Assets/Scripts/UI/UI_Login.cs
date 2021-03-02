using UnityEngine;
public class UI_Login : UIBase
{

    Canvas CanvasInst;

    private void Awake()
    {
        CanvasInst = GetComponent<Canvas>();
        CanvasInst.worldCamera = Camera.main;
    }

    public void OnLogin()
    {

        FightManager.Inst.GameProcedure = AttTypeDefine.eGameProcedure.eFightStart;

        UIManager.Inst.CloseUI<UI_Login>(this, true);
    }

}
