using UnityEngine;
using AttTypeDefine;
public class BasePlayer : MonoBehaviour
{

    private float playerraidus;
    public float PlayerRadius => (playerraidus);

    protected AnimatorManager AnimMgr;
 
    private CharacterController characterCtrl;

    public CharacterController CharacCtrl => (characterCtrl);

    public float PlayerHeight => (characterCtrl.height);

    [HideInInspector]
    public string PlayerName;
    //hp, attack

    private BaseAttributes _BaseAttr;
    public BaseAttributes BaseAttr => (_BaseAttr);


    [HideInInspector]
    public Vector3 ClosestHitPoint;

    public Vector2[] AnimPerArray;
    public Vector2[] AnimSkillPerArray;

    public ePlayerSide PlayerSide;

    protected Animator _Anim;
    public Animator Anim => (_Anim);

    protected int TypeId;

    public int TypeID => (TypeId);

    protected string roleId;
    public string RoleID => (roleId);


    protected virtual void Awake()
    {
        _BaseAttr = gameObject.AddComponent<BaseAttributes>();

        characterCtrl = GetComponent<CharacterController>();

        AnimMgr = gameObject.AddComponent<AnimatorManager>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _Anim = GetComponent<Animator>();
        _BaseAttr.InitPlayerAttr(this, PlayerName);

        playerraidus = characterCtrl.radius * transform.localScale.x;

    }

   

}
