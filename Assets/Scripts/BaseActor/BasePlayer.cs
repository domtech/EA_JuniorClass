using UnityEngine;
using AttTypeDefine;
public class BasePlayer : MonoBehaviour
{


    private CharacterController characterCtrl;

    public CharacterController CharacCtrl => (characterCtrl);

    public float PlayerHeight => (characterCtrl.height);

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


    protected virtual void Awake()
    {
        _BaseAttr = gameObject.AddComponent<BaseAttributes>();

        characterCtrl = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _Anim = GetComponent<Animator>();
        _BaseAttr.InitPlayerAttr(this, PlayerName);
    }

   

}
