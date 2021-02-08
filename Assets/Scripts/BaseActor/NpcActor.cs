using UnityEngine;

public class NpcActor : BasePlayer
{


    protected override void Start()
    {
        base.Start();
    }

    public void GetHit()
    {
        Anim.SetTrigger("Base Layer.GetHit");
    }

}
