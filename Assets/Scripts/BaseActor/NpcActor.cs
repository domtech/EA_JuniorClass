using UnityEngine;

public class NpcActor : BasePlayer
{

    public UI_HUD NpcHUD;
    protected override void Start()
    {
        base.Start();
    }

    public void GetHit()
    {
        Anim.SetTrigger("Base Layer.GetHit");
    }


    public void Update()
    {
        NpcHUD.SetHUDPos(this);
    }

    public void UpdateHp (float hp)
    {
        NpcHUD.UpdateHp(hp);
    }

}
