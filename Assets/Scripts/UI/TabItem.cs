using UnityEngine;
using UnityEngine.UI;

public class TabItem : MonoBehaviour
{

    public Image ChoosenImageInst;




    public void SetTabItemState(bool on)
    {

        ChoosenImageInst.gameObject.SetActive(on);
    }
}
