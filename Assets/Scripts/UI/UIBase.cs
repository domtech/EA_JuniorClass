using UnityEngine;

public class UIBase : MonoBehaviour
{
    protected Canvas CanvasInst;
    protected virtual void Awake()
    {
        CanvasInst = GetComponent<Canvas>();
        CanvasInst.worldCamera = Camera.main;
    }

}
