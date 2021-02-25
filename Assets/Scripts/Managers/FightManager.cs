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
                            //�������
                            PlayerInst = AnimCtrl.CreatePlayerActor(ConstData.PlayerName, BP);

                            //�������
                            CamMgr.OnStart(PlayerInst);

                            for(var i = 0; i < EnemyBP.Length; i++)
                            {
                                var enemy = NpcActor.CreateNpcActor(ConstData.SkeleName, EnemyBP[i]);
                                enemy.OnStart(PlayerInst);
                                AddEnemy(enemy);
                            }
                            //���ع���
                           
                            break;
                        }
                    case eGameProcedure.eFightOver:
                        {

                            if(PlayerInst.BaseAttr[ePlayerAttr.eHP] == 0 && EnemyList.Count > 0)//��ʤ��
                            {
                                PlayerInst.SetPlayerGameOver(false);//��ҵ������߼�
                                SetEnemyVictory();//���˵Ļ���
                            }
                            else if(EnemyList.Count == 0 && PlayerInst.BaseAttr[ePlayerAttr.eHP] >0)//���ʤ��
                            {
                                PlayerInst.SetPlayerGameOver(true);//���ʤ���߼�
                            }
                            break;
                        }
                    case eGameProcedure.eRestart:
                        {
                            //��������е���������
                            //���¼�����������
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
