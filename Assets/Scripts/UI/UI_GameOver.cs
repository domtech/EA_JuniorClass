using UnityEngine;

public class UI_GameOver : UIBase
{
  
    public void PressReStartBtn()
    {
        FightManager.Inst.GameProcedure = AttTypeDefine.eGameProcedure.eRestart;
        UIManager.Inst.CloseUI<UI_GameOver>(this, true);
    }

    public void PressQuitGame()
    {
        Application.Quit();
    }

}
