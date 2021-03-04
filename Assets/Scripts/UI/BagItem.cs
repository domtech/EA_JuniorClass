using UnityEngine;
using UnityEngine.UI;

public class BagItem : MonoBehaviour
{
    Image Icon;
    UI_Bag BagInst;
    public GameObject Choosen;

    public void OnStart (UI_Bag bag)
    {
        BagInst = bag;
    }

    private void Awake()
    {
        Icon = GetComponent<Image>();
    }

    public void SetBagItemIcon(Sprite sp)
    {
        Icon.sprite = sp;
    }

    public void ClickBagItem()
    {

        if (Choosen == BagInst.LastClickItem)
            return;

        Choosen.SetActive(true);
        if(null != BagInst.LastClickItem)
        {
            BagInst.LastClickItem.SetActive(false);
        }
        BagInst.LastClickItem = Choosen;

    }

}
