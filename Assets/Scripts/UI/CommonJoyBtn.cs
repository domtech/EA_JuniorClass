using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommonJoyBtn : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    #region Joy Stick Event Callback
    public Transform TransBackground;
    public Transform TransHandle;
    public float MaxRadius;

    Vector3 _Dir;
    public Vector3 Dir => (_Dir);


    Vector3 PointDownPos;
    int FingerId = int.MinValue;
    public void OnPointerDown(PointerEventData eventData)
    {
        if( (FingerId = eventData.pointerId) < -1)
        {
            return;
        }

        TransBackground.position = PointDownPos = eventData.position;

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

        TransHandle.localPosition = localPos;

        _Dir = TransHandle.localPosition.normalized;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if ((FingerId = eventData.pointerId) < -1)
        {
            return;
        }

        _Dir = TransHandle.localPosition = Vector3.zero;

    }
    #endregion
}
