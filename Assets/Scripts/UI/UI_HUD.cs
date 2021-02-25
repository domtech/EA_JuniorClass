
using UnityEngine;
using UnityEngine.UI;

public class UI_HUD : UIBase
{

    public Slider HPSlider;

    Camera Cam;

    public float Duration;

    private float StartTime;

    private bool IsTrigger = false;
    

    private void Start()
    {
        Cam = Camera.main;
        
    }

    //��ʼ��������
    //�ڽ����У����п�ʼ����ô����Ҫ����
    public void SetHUDPos(BasePlayer NpcTrans)
    {
        if(IsTrigger)
        {
            HPSlider.transform.position = Cam.WorldToScreenPoint(NpcTrans.transform.position + Vector3.up * NpcTrans.PlayerHeight * 0.7f);
        }
    }

    private void Update()
    {
        //time counter
        if(IsTrigger)
        {
            if(Time.time - StartTime > Duration)
            {
                gameObject.SetActive(false);
                IsTrigger = false;
            }
        }
    }

    public void UpdateHp(float hp)
    {
        StartTime = Time.time;
        IsTrigger = true;
        gameObject.SetActive(true);
        HPSlider.value = hp;
    }

}
