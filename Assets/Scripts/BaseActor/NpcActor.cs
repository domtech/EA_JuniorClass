using UnityEngine;

public class NpcActor : MonoBehaviour
{
    Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        Anim.SetTrigger("Base Layer.GetHit");

    }

}
