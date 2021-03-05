
using UnityEngine;

public class FSMBehaviour : MonoBehaviour
{
    FSMSystem SysInst;

    private void Awake()
    {
        SysInst = new FSMSystem();
    }

  
}
