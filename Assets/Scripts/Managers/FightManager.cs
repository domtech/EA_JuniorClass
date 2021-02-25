using UnityEngine;
using AttTypeDefine;
using System.Collections.Generic;

public class FightManager : MonoBehaviour
{

    private static FightManager inst;

    public static FightManager Inst => (inst);

    AnimCtrl PlayerInst;

    List<BasePlayer> EnemyList ;

    CamManager CamMgr;

    public BirthPoint BP;

    public BirthPoint EnemyBP;

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
                            //�������
                            PlayerInst = AnimCtrl.CreatePlayerActor(ConstData.PlayerName, BP);

                            //�������
                            CamMgr.OnStart(PlayerInst);

                            //���ع���
                            var enemy = NpcActor.CreateNpcActor(ConstData.SkeleName, EnemyBP);
                            enemy.OnStart(PlayerInst);
                            AddEnemy(enemy);
                            break;
                        }
                    case eGameProcedure.eFighing:
                        {
                            break;
                        }
                    case eGameProcedure.eFightOver:
                        {
                            PlayerInst.SetPlayerDeath();//��ҵ������߼�
                            SetEnemyVictory();//���˵Ļ���
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

}
