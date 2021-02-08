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


        //if(IsTakeDamage)
        {
            //hp defencer
            //attack  attacker
        }


        //play injure animation.
        switch(AnimID)
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
