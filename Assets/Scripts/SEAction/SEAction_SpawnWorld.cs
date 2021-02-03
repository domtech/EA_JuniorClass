using UnityEngine;

public class SEAction_SpawnWorld : MonoBehaviour
{
    SEAction_DataStore se;
    public GameObject EffectSpawnInst;

    public string SocketName;

    public Vector3 OffSet;
    public Vector3 OffRot;

    GameObject Owner;
    // Start is called before the first frame update
    void Start()
    {

        se = GetComponent<SEAction_DataStore>();

        Owner = se.Owner;

        var socket = GlobalHelper.FindGOByName(Owner, SocketName);

        if(socket == null)
        {
            socket = Owner;
        }

        //spawn effect
        var effect = Instantiate(EffectSpawnInst);

        effect.transform.rotation = Quaternion.Euler(OffRot);

        effect.transform.position = socket.transform.position + OffSet;

      

    }

   
}
