using UnityEngine;

public class UI_Login : UIBase
{

    BirthPoint BP;
    public void OnStart(BirthPoint bp)
    {
        BP = bp;
    }
   
    public void OnLogin()
    {
        var Player = AnimCtrl.CreatePlayerActor(ConstData.PlayerName, BP);
        UIManager.Inst.CloseUI<UI_Login>(this, true);
    }

}
