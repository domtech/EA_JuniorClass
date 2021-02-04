using UnityEngine;

public class SEAction_SpawnWorld : SEAction_BaseAction
{
    SEAction_DataStore se;

    [HideInInspector]
    public GameObject EffectSpawnInst;

    [HideInInspector]
    public string SocketName;
    [HideInInspector]
    public float EffectDestroyDelay;
    [HideInInspector]
    public Vector3 OffSet;
    [HideInInspector]
    public Vector3 OffRot;

    GameObject Owner;

    public override void TrigAction()
    {
        se = GetComponent<SEAction_DataStore>();

        Owner = se.Owner;

        var socket = GlobalHelper.FindGOByName(Owner, SocketName);

        if (socket == null)
        {
            socket = Owner;
        }

        //spawn effect
        var effect = Instantiate(EffectSpawnInst);

        var des = effect.GetComponent<SEAction_Destruction>();
        if(null != des)
        {
            des.Duration = EffectDestroyDelay;
            des.OnStart();
        }

        effect.transform.rotation = socket.transform.rotation;
        effect.transform.Rotate(OffRot, Space.Self);

        effect.transform.position = socket.transform.position;
        effect.transform.Translate(OffSet, Space.Self);



    }

}
