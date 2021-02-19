using UnityEngine;
using AttTypeDefine;
public class SEAction_BuffTakeDamage : SEAction_BaseAction
{
    

    [HideInInspector]
    public eStateID AnimID;


    /*
     * 
     * µÙ—™
     * 
     * ≤•∑≈ ‹…À∂Øª≠
     * */
    public override void TrigAction()
    {

        var ds = GetDataStore();

        var attacker = ds.Owner.GetComponent<BasePlayer>();

        var defencer =ds.Target.GetComponent<BasePlayer>();


        //1 : hp
        //2 : attack
        var hp = defencer.BaseAttr[ePlayerAttr.eHP];

        var attack = attacker.BaseAttr[ePlayerAttr.eAttack];


        if(attacker.PlayerSide == ePlayerSide.ePlayer)
        {
            ((AnimCtrl)attacker).OnModifyFSV(25);
        }


        hp -= attack;

        if (hp <= 0)
        {
            defencer.BaseAttr[ePlayerAttr.eHP] = 0;

            if (defencer.PlayerSide == ePlayerSide.eEnemy)
            {
                ((NpcActor)defencer).SetAIState(eStateID.eDie);
                ((AnimCtrl)attacker).EnemyDie(defencer.transform);
            }
           
        }
        else
        {

            defencer.BaseAttr[ePlayerAttr.eHP] = hp;

            //play injure animation.
            switch (AnimID)
            {
                case eStateID.eGetHit:
                    {

                        if(defencer.PlayerSide == ePlayerSide.eEnemy)
                        {
                            ((NpcActor)defencer).SetAIState(eStateID.eGetHit);
                        }
                        else if(defencer.PlayerSide == ePlayerSide.ePlayer)
                        {
                            ((AnimCtrl)defencer).PlayerGetHit();
                        }

                        break;
                    }
                case eStateID.eFlyAway:
                    {
                        if (defencer.PlayerSide == ePlayerSide.eEnemy)
                        {
                            ((NpcActor)defencer).SetAIState(eStateID.eFlyAway);
                        }
                        break;
                    }
            }

        }
    }

}
