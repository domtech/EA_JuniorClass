using UnityEngine;
using AttTypeDefine;
using UnityEngine.UI;

public class UI_MainCity : UIBase
{

    #region StartGame

    GameObject PlayerInst;

    public RawImage RawImageInst;

    Camera Cam;
    RenderTexture TargetTexture;
    bool IsTrigger = false;

    

    public void OnStart ()
    {
        if(null != PlayerInst && null != Cam)
        {
            Cam.gameObject.SetActive(true);

            PlayerInst.SetActive(true);
        }
        else
        {
            base.Awake();

            PlayerInst = GlobalHelper.InstantiateMyPrefab("Models/Daughter_02", Vector3.right * 30f, Quaternion.identity);

            var weapon = GlobalHelper.FindGOByName(PlayerInst, "greatesword");

            weapon.SetActive(false);

            var Anim = PlayerInst.GetComponent<Animator>();

            Anim.runtimeAnimatorController = Instantiate(Resources.Load("AnimatorController/Daughter02AnimCtrl")) as RuntimeAnimatorController;


            TargetTexture = new RenderTexture((int)RawImageInst.rectTransform.rect.width, (int)RawImageInst.rectTransform.rect.height, 8, RenderTextureFormat.ARGB32);

            RawImageInst.texture = TargetTexture;

            GameObject CamObj = new GameObject("CamObj");

            Cam = CamObj.AddComponent<Camera>();

            Cam.targetTexture = TargetTexture;
        }

        IsTrigger = true;

    }


    private void Update()
    {

        if(IsTrigger)
        {
            var PlayerTrans = PlayerInst.transform;

            Cam.transform.position = PlayerTrans.position + PlayerTrans.forward * 2f + Vector3.up * 1.5f;

            Cam.transform.LookAt(PlayerTrans.position + Vector3.up);

            Cam.Render();
        }

    }



    public void StartGame()
    {
        FightManager.Inst.SetGameProcedure(eGameProcedure.eFightStart);

        UIManager.Inst.CloseUI<UI_MainCity>(this);

        Cam.gameObject.SetActive(false);

        PlayerInst.SetActive(false);

        IsTrigger = false;
    }
    #endregion
}

//

//protected override void Awake()
//{
//    if(!IsTrigger)
//    {



//    }


//}

//private void Start()
//{
//    if (!IsTrigger)
//    {
//        TargetTexture = new RenderTexture((int)RawImageInst.rectTransform.rect.width, (int)RawImageInst.rectTransform.rect.height, 8, RenderTextureFormat.ARGB32);

//        RawImageInst.texture = TargetTexture;

//        GameObject CamObj = new GameObject("CamObj");

//        Cam = CamObj.AddComponent<Camera>();

//        Cam.targetTexture = TargetTexture;

//        IsTrigger = true;
//    }
//    else
//    {
//        Cam.gameObject.SetActive(IsTrigger);

//        PlayerInst.SetActive(IsTrigger);
//    }

//}