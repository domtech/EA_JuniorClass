using AttTypeDefine;
using UnityEngine;

public class BagTabCtrl : MonoBehaviour
{

    public GameEventInt EventInst;

    TabItem[] TabItemArray;

    int tabIndex = -1;
    public int TabIndex
    {
        get
        {
            return tabIndex;
        }
        set
        {
            if (value != tabIndex)
            {
                tabIndex = value;
                EventInst.Invoke(tabIndex);
            } 
        }
    }

    private void Start()
    {
      
        TabItemArray = gameObject.GetComponentsInChildren<TabItem>();
        TabIndex = 0;
        TabItemArray[tabIndex].SetTabItemState(true);
    }

    



    public void ClickTabItem(int index)
    {
        for(var i = 0; i < TabItemArray.Length; i++)
        {
            if(i == index)
            {
                TabIndex = i;
                TabItemArray[i].SetTabItemState(true);
            }
            else
            {
                TabItemArray[i].SetTabItemState(false);
            }
        }
    }

}
