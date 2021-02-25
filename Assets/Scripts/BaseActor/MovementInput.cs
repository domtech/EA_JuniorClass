using UnityEngine;
using Tur4;
public class MovementInput : MonoBehaviour
{
    #region System Function

    public void OnStart(AnimCtrl ac)
    {
        Cam = Camera.main;

        AnimCtrlInst = ac;

        CharCtrl = ac.CharacCtrl;

        JoyStick = ac.JoyStickInst;

        Anim = ac.Anim;
    }

    void Update()
    {

        if (null == AnimCtrlInst)
            return;

        if(CanMove())
        {
            SetPlayerAnimMovePam();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(null !=other.gameObject.GetComponent<Tur4Bullet>())
    //    {
    //        Destroy(other.gameObject);
    //        //player play hit.
    //        Anim.SetTrigger("Base Layer.GetHit");
    //    }

    //}
    #endregion

    #region Player Animation Controller
    private AnimCtrl AnimCtrlInst;
    Animator Anim;
    CharacterController CharCtrl;
    UI_JoyStick JoyStick;
    float horizontal;
    float vertical;
    float speed;
    float s1;
    float s2;

    Camera Cam;


    bool CanMove()
    {

        if (AnimCtrlInst.IsPlaying)//当前是否在播放攻击动画
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void SetPlayerAnimMovePam()
    {

#if UNITY_EDITOR
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        s1 = Mathf.Sqrt(horizontal * horizontal + vertical * vertical); ;
        s2 = null != JoyStick ? JoyStick.Dir.magnitude : 0;

        speed = s1 > s2 ? s1 : s2;

        if(s2 > s1)
        {
            horizontal = JoyStick.Dir.x;
            vertical = JoyStick.Dir.y;
        }
#else
        speed = JoyStick.Dir.magnitude;
#endif

        Anim.SetFloat("IdleAndRun", speed);

        if(speed > 0.01f)
        {
            PlayerCtrlMovement(horizontal, vertical);
        }
    }

    void PlayerCtrlMovement(float x, float z)
    {

        var dir = x * Cam.transform.right + z * Cam.transform.forward;

        dir.y = 0f;

        transform.forward = dir;

        CharCtrl.Move(AnimCtrlInst.BaseAttr.Speed * Time.deltaTime * dir);
    }

    #endregion

}
