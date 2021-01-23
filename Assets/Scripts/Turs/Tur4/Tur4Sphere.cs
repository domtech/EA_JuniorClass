using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tur4Sphere : MonoBehaviour
{
    bool IsTriggered = false;


    public void OnStart ()
    {

    }


    private void Update()
    {
        if (!IsTriggered)
            return;

        if (transform.position.y > 10f)
            Destroy(gameObject);

        transform.position += Vector3.up * 2f * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        transform.DOScale(0.2f, 0.5f).OnComplete(()=> {
            IsTriggered = true;
        });
        
    }

}
