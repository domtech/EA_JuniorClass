
using UnityEngine;


public class SEAction_BuffSpawnWorld : SEAction_BaseAction
{
    SEAction_DataStore se;

    [HideInInspector]
    public GameObject EffectSpawnInst;

    [HideInInspector]
    public float EffectDestroyDelay;

    [HideInInspector]
    public float EffectScale = 1;

    public override void TrigAction()
    {
        se = GetComponent<SEAction_DataStore>();


        var defencer = se.Target;

        var defencerBasePlayer = defencer.GetComponent<BasePlayer>();

        //spawn effect
        var effect = Instantiate(EffectSpawnInst);

        effect.transform.localScale = Vector3.one * EffectScale;

        var des = effect.GetComponent<SEAction_Destruction>();
        if (null != des)
        {
            des.Duration = EffectDestroyDelay;
            des.OnStart();
        }

        
        effect.transform.position = defencerBasePlayer.ClosestHitPoint;



    }
}
