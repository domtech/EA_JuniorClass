
using UnityEngine;
using UnityEngine.UI;

public class UI_LoadingV2 : UIBase
{


    bool IsTrigger = false;

    public Slider SliderInst;

    public float Speed;

    public Text TextInst;


    public void OnStart ()
    {
        SetUIState();
    }

    private void Update()
    {

        if (!IsTrigger)
            return;

        if(SliderInst.value >= 1f)
        {
            TextInst.text = "100%";
            TriggerGame();
            return;
        }
        else
        {
            SliderInst.value += Speed * Time.deltaTime;
            TextInst.text = ((int)(SliderInst.value * 100)).ToString() + "%";
        }
    }

    void TriggerGame()
    {
        SetUIState();
        FightManager.Inst.GameProcedure = AttTypeDefine.eGameProcedure.eFightStart;
        UIManager.Inst.CloseUI<UI_LoadingV2>(this);
    }

    void SetUIState()
    {
        IsTrigger = !IsTrigger;
        SliderInst.value = 0f;
    }



}
