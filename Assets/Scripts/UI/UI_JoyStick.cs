using UnityEngine;
using UnityEngine.UI;

public class UI_JoyStick : MonoBehaviour
{

    #region Sys

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
    public int AngryIncrease = 10;
    public Image HighLight1;
    public Image HighLight2;
    public bool ShowFinalSkillBtn => (SliderInst.value >= 100);


    public void OnModifyFSV ()
    {
        var angryValue = SliderInst.value;
        SliderInst.value += AngryIncrease;

        if(SliderInst.value >= 100 && angryValue < 100)
        {
            HighLight1.enabled = true;
        }
        else if(SliderInst.value >= 200 && angryValue < 200)
        {
            HighLight2.enabled = true;
        }

        FinalSkillBtnInst.SetFinalSkillState(ShowFinalSkillBtn);

    }
    #endregion

    #region FinalSkill
    public FinalSkillBtn FinalSkillBtnInst;
    #endregion
}
