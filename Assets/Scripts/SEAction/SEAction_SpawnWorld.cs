using UnityEngine;

public class SEAction_SpawnWorld : SEAction_BaseAction
{
    SEAction_DataStore se;
    public GameObject EffectSpawnInst;

    public string SocketName;

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

        effect.transform.rotation = Quaternion.Euler(OffRot);

        effect.transform.position = socket.transform.position + OffSet;
    }

}
