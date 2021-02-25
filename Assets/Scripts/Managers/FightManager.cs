using UnityEngine;
using AttTypeDefine;
using System.Collections.Generic;

public class FightManager : MonoBehaviour
{

    private static FightManager inst;

    public static FightManager Inst => (inst);

    AnimCtrl PlayerInst;

    List<BasePlayer> EnemyList ;

    public int LeftEnemyCount => (EnemyList.Count);

    CamManager CamMgr;

    public BirthPoint BP;

    public BirthPoint[] EnemyBP;

    eGameProcedure gameprocedure = eGameProcedure.eNULL;
    public eGameProcedure GameProcedure
    {
        get
        {
            return gameprocedure;
        }
        set
        {
            if(value != gameprocedure)
            {
                switch(value)
                {
                    case eGameProcedure.eFightStart:
                        {
                            //加载玩家
                            PlayerInst = AnimCtrl.CreatePlayerActor(ConstData.PlayerName, BP);

                            //启动相机
                            CamMgr.OnStart(PlayerInst);

                            for(var i = 0; i < EnemyBP.Length; i++)
                            {
                                var enemy = NpcActor.CreateNpcActor(ConstData.SkeleName, EnemyBP[i]);
                                enemy.OnStart(PlayerInst);
                                AddEnemy(enemy);
                            }
                            //加载怪兽
                           
                            break;
                        }
                    case eGameProcedure.eFightOver:
                        {

                            if(PlayerInst.BaseAttr[ePlayerAttr.eHP] == 0 && EnemyList.Count > 0)//怪胜利
                            {
                                PlayerInst.SetPlayerGameOver(false);//玩家的死亡逻辑
                                SetEnemyVictory();//敌人的欢呼
                            }
                            else if(EnemyList.Count == 0 && PlayerInst.BaseAttr[ePlayerAttr.eHP] >0)//玩家胜利
                            {
                                PlayerInst.SetPlayerGameOver(true);//玩家胜利逻辑
                            }
                            break;
                        }
                    case eGameProcedure.eRestart:
                        {
                            //清理掉现有的所有数据
                            //重新加载所需数据
                            RestartGame();
                            break;
                        }
                }
                gameprocedure = value;
            }
        }
    }


    #region Enemy Mgr
     void AddEnemy(BasePlayer bp) 
    {
        EnemyList.Add(bp);
    }

    public void RemoveEnemy(BasePlayer bp) 
    {
        EnemyList.Remove(bp);

    }

    public void SetEnemyVictory()
    {
        for(var i = 0; i < EnemyList.Count; i++)
        {
            //play victory animation
            var item = EnemyList[i];

            ((NpcActor)item).SetAIState(eStateID.eVictory);
          
        }
    }


    #endregion

    private void Awake()
    {
        inst = this;
        EnemyList = new List<BasePlayer>();
        var GOCam = Instantiate(Resources.Load("Maps/Cams")) as GameObject;
        CamMgr = GOCam.GetComponent<CamManager>();
    }

    private void Start()
    {
        UIManager.Inst.OpenUI<UI_Login>();
    }

    void RestartGame()
    {
        Destroy(PlayerInst.gameObject);

        while(EnemyList.Count > 0)
        {
            var item = EnemyList[0];
            EnemyList.Remove(item);
            NpcActor.DestroySelf((NpcActor)item);
        }

        UIManager.Inst.OpenUI<UI_Login>();

    }

}
