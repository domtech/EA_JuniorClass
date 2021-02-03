using UnityEngine;

public class SEAction_SpawnWorld : SEAction_BaseAction
{
    SEAction_DataStore se;
    public GameObject EffectSpawnInst;

    public string SocketName;

    public float EffectDestroyDelay;

    public Vector3 OffSet;
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
