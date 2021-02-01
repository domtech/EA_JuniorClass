using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using AttTypeDefine;

public class CommonJoyBtn : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    #region sys
    void Awake()
    {
        PressDown = new GameBtnEvent();
        OnDragEvent = new GameBtnEvent();
        PressUp = new GameBtnEvent();
    }
    #endregion

    #region Joy Stick Event Callback
    public Image ImageBackground;
    public Image ImageHandle;
    public float MaxRadius;

    public GameBtnEvent PressDown;
    public GameBtnEvent OnDragEvent;
    public GameBtnEvent PressUp;


    protected Vector3 _Dir;
    public Vector3 Dir => (_Dir);

    Vector3 PointDownPos;
    int FingerId = int.MinValue;
    public void OnPointerDown(PointerEventData eventData)
    {
        if( (FingerId = eventData.pointerId) < -1)
        {
            return;
        }

        ImageBackground.transform.position = PointDownPos = eventData.position;

        PressDown?.Invoke(eventData);


    }
    public void OnDrag(PointerEventData eventData)
    {
        if ((FingerId = eventData.pointerId) < -1)
        {
            return;
        }

        //get distance
        var distance = (eventData.position - (Vector2)PointDownPos);

        var radius = Mathf.Clamp(Vector3.Magnitude(distance), 0, MaxRadius);

        var tmp = radius * distance.normalized;

        var localPos = new Vector2()
        {
            x = tmp.x,
            y = tmp.y
        };

        ImageHandle.transform.localPosition = localPos;

        _Dir = ImageHandle.transform.localPosition.normalized;

        OnDragEvent?.Invoke(eventData);



    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if ((FingerId = eventData.pointerId) < -1)
        {
            return;
        }

        _Dir = ImageHandle.transform.localPosition = Vector3.zero;

        PressUp?.Invoke(eventData);


    }
    #endregion
}
