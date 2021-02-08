using UnityEngine;
using AttTypeDefine;
public class SEAction_BuffTakeDamage : SEAction_BaseAction
{
    

    [HideInInspector]
    public StateID AnimID;


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


        hp -= attack;

        if (hp <= 0)
        {
            defencer.BaseAttr[ePlayerAttr.eHP] = 0;

            defencer.PlayAnim("Base Layer.Die");
        }
        else
        {

            defencer.BaseAttr[ePlayerAttr.eHP] = hp;

            //play injure animation.
            switch (AnimID)
            {
                case StateID.eGetHit:
                    {
                        defencer.PlayAnim("Base Layer.GetHit");
                        break;
                    }
                case StateID.eFlyAway:
                    {
                        break;
                    }
            }

        }
    }

}
