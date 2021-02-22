using UnityEngine;
using UnityEngine.UI;

public class UI_JoyStick : UIBase
{

    #region Sys
    public void OnStart()
    {
        FinalSkillBtnInst.Init();
    }
    private void Start()
    {
        FinalSkillBtnInst.SetFinalSkillState(ShowFinalSkillBtn);
    }
    #endregion

    #region JoyStick
    public CommonJoyBtn CommonBtn;
    public Vector3 Dir => (CommonBtn.Dir);
    #endregion

    #region Angry Slider
    public Slider SliderInst;
    public Image HighLight1;
    public Image HighLight2;
    public bool ShowFinalSkillBtn => (SliderInst.value >= 100);


    public void OnModifyFSV (int value)
    {
        var angryValue = SliderInst.value;
        SliderInst.value += value;


        if (SliderInst.value >= 100 && angryValue < 100)
        {
            HighLight1.enabled = true;
        }
        else if (SliderInst.value >= 200 && angryValue < 200)
        {
            HighLight2.enabled = true;
        }
        else if(SliderInst.value >= 100 && SliderInst.value < 200)
        {
            HighLight1.enabled = true;
            HighLight2.enabled = false;
        }
        else if(SliderInst.value < 100)
        {
            HighLight1.enabled = false;
            HighLight2.enabled = false;
        }
        else if(SliderInst.value >= 200)
        {
            HighLight1.enabled = true;
            HighLight2.enabled = true;
        }
      
        FinalSkillBtnInst.SetFinalSkillState(ShowFinalSkillBtn);

    }
    #endregion

    #region FinalSkill
    public FinalSkillBtn FinalSkillBtnInst;
    #endregion
}
