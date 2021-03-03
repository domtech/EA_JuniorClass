using UnityEngine;
using UnityEngine.UI;
using AttTypeDefine;
public class UI_Loading : UIBase
{
    public Slider SliderInst;
    public Text TextInst;
    bool IsTrigger = false;
    public float PercentSpeed;


    public void OnStart()
    {
        IsTrigger = true;
        SliderInst.value = 0f;
    }

    private void Update()
    {
        if (!IsTrigger)
            return;

        if(SliderInst.value >=1f)
        {
            TextInst.text = "100%";
            Invoke("TriggerGame", 0.1f);
            return;
        }
        else
        {
            SliderInst.value += PercentSpeed * Time.deltaTime;
            TextInst.text = ((int)(SliderInst.value*100f)).ToString() + "%";
        }
    }

    void TriggerGame()
    {
        SliderInst.value = 0f;
        IsTrigger = false;
        TextInst.text = "0%";
        var maincity = UIManager.Inst.OpenUI<UI_MainCity>();
        maincity.OnStart();

        UIManager.Inst.CloseUI<UI_Loading>(this);
    }

}

