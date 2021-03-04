using UnityEngine;

public class BagTabCtrl : MonoBehaviour
{

    TabItem[] TabItemArray;

    int tabIndex = 0;
    public int TabIndex => tabIndex;

    private void Awake()
    {
       
        TabItemArray = gameObject.GetComponentsInChildren<TabItem>();
        tabIndex = 0;
        TabItemArray[tabIndex].SetTabItemState(true);
    }

    public void ClickTabItem(int index)
    {
        for(var i = 0; i < TabItemArray.Length; i++)
        {
            if(i == index)
            {
                tabIndex = i;
                TabItemArray[i].SetTabItemState(true);
            }
            else
            {
                TabItemArray[i].SetTabItemState(false);
            }
        }
    }

}
