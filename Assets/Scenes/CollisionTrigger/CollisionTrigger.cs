using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 20f * Time.deltaTime, 0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
