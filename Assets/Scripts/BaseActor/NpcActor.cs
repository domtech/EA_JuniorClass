using UnityEngine;

public class NpcActor : MonoBehaviour
{
    Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void GetHit()
    {
        Anim.SetTrigger("Base Layer.GetHit");
    }

}
