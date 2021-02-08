using UnityEngine;
using AttTypeDefine;
public class BasePlayer : MonoBehaviour
{

    [HideInInspector]
    public Vector3 ClosestHitPoint;

    public Vector2[] AnimPerArray;
    public Vector2[] AnimSkillPerArray;

    public ePlayerSide PlayerSide;

    protected Animator _Anim;
    public Animator Anim => (_Anim);

    protected int TypeId;

    public int TypeID => (TypeId);


    // Start is called before the first frame update
    protected virtual void Start()
    {
        _Anim = GetComponent<Animator>();
    }

    public void PlayAnim(string animName)
    {
        _Anim.SetTrigger(animName);
    }

}
