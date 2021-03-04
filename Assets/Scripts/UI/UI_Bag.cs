using UnityEngine;
using AttTypeDefine;


public class UI_Bag : UIBase
{
    public BagTabCtrl BagTabInst;

    public Transform ScrollContent;

    public Sprite[] SpriteArray;

    BagItem[] BgItemArray;

    [HideInInspector]
    public GameObject LastClickItem;

    protected override void Awake()
    {
        base.Awake();
        BagTabInst.EventInst = new GameEventInt();
        BagTabInst.EventInst.AddListener((b) => TabChanged(b));

        BgItemArray = ScrollContent.GetComponentsInChildren<BagItem>();
        for (var i = 0; i < BgItemArray.Length; i++)
        {
            BgItemArray[i].OnStart(this);
        }
    }

    void TabChanged(int index)
    {
        Debug.Log(index);

        for(var i = 0; i< BgItemArray.Length; i++)
        {
            BgItemArray[i].SetBagItemIcon(SpriteArray[index]);
        }

    }


}
