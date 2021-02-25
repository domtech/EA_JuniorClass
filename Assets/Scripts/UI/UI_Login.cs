using UnityEngine;
public class UI_Login : UIBase
{

    BirthPoint BP;
    BirthPoint EnemyBP;
    CamManager CamMgr;
    public void OnStart(BirthPoint bp, BirthPoint enybp, CamManager cammgr)
    {
        BP = bp;
        CamMgr = cammgr;
        EnemyBP = enybp;
    }
   
    public void OnLogin()
    {

        //加载玩家
        var Player = AnimCtrl.CreatePlayerActor(ConstData.PlayerName, BP);

        //启动相机
        CamMgr.OnStart(Player);

        //加载怪兽
        var enemy = NpcActor.CreateNpcActor(ConstData.SkeleName, EnemyBP);
        enemy.OnStart(Player);

        UIManager.Inst.CloseUI<UI_Login>(this, true);
    }

}
