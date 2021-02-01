using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSkillBtn : CommonJoyBtn
{
    public Color NormalColor;
    public Color DisabledColor;
    public CanvasGroup CanvasGpInst;


    public void SetFinalSkillState (bool on)
    {
        CanvasGpInst.blocksRaycasts = on;

        ImageBackground.color = (on == true) ? NormalColor : DisabledColor;
        ImageHandle.color = (on == true) ? NormalColor : DisabledColor;
    }
        

}
