using AttTypeDefine;
using UnityEngine;

public class FinalSkillBtn : CommonJoyBtn
{
    public Color NormalColor;
    public Color DisabledColor;
    public CanvasGroup CanvasGpInst;

    public override void Awake()
    {
        
    }

    public void Init()
    {
        PressDown = new GameBtnEvent();
        OnDragEvent = new GameBtnEvent();
        PressUp = new GameBtnEvent();
    }

    public void SetFinalSkillState (bool on)
    {
        CanvasGpInst.blocksRaycasts = on;

        ImageBackground.color = (on == true) ? NormalColor : DisabledColor;
        ImageHandle.color = (on == true) ? NormalColor : DisabledColor;
    }
        

}
