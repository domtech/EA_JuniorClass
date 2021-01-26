using UnityEngine;
using Tur4;
public class MovementInput : MonoBehaviour
{
    #region System Function
    void Update()
    {
        SetPlayerAnimMovePam();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(null !=other.gameObject.GetComponent<Tur4Bullet>())
        {
            Destroy(other.gameObject);
            //player play hit.
            Anim.SetTrigger("Base Layer.GetHit");
        }

    }
    #endregion

    #region Player Animation Controller
    public Animator Anim;
    public CharacterController CharCtrl;
    public float MoveSpeed;
    public UI_JoyStick JoyStick;
    float horizontal;
    float vertical;
    float speed;
    float s1;
    float s2;

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

        var dir = x * Vector3.right + z * Vector3.forward;


        transform.forward = dir;

        CharCtrl.Move(MoveSpeed * Time.deltaTime * dir);
    }

    #endregion

    #region GetHit
    #endregion
}
