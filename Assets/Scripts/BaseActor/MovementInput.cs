using UnityEngine;

public class MovementInput : MonoBehaviour
{

    #region System Function
    // Update is called once per frame
    void Update()
    {
        SetPlayerAnimMovePam();
    }
    #endregion

    #region Player Animation Controller
    public Animator Anim;

    float horizontal;
    float vertical;
    float speed;
    void SetPlayerAnimMovePam()
    {
#if UNITY_EDITOR
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
#else
        int a = 0;
#endif
        speed = Mathf.Sqrt(horizontal* horizontal + vertical * vertical);

        Anim.SetFloat("IdleAndRun", speed);

    }
#endregion


}
