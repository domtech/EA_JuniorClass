using Cinemachine;
using UnityEngine;

public class CamManager : MonoBehaviour
{

    public CinemachineFreeLook FreeLook;

    AnimCtrl Owner;
    Camera Cam;
    private void Awake()
    {
        Cam = Camera.main;
    }

    public void OnStart (AnimCtrl player)
    {
        Owner = player;
        FreeLook.LookAt = Owner.transform;
        FreeLook.Follow = Owner.transform;

    }

  
}
