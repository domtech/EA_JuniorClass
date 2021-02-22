
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Inst => (inst);
    private static UIManager inst;

    private void Awake()
    {
        inst = this;
    }


    //加载UI
    public T OpenUI<T> () where T : UIBase
    {
        for(var i = 0; i < transform.childCount; i++)
        {
            var item = transform.GetChild(i);

            if(item.name == typeof(T).Name)
            {
                item.gameObject.SetActive(true);
                return item.GetComponent<T>();
            }

        }

        //加载一下我们的新UI
        var tmp = Resources.Load("UI/" + typeof(T).Name);
        var uiitem = Instantiate(tmp) as GameObject;
        uiitem.name = tmp.name;
        uiitem.transform.parent = transform;
        uiitem.transform.localPosition = Vector3.zero;
        uiitem.transform.localRotation = Quaternion.identity;
        uiitem.transform.localScale = Vector3.one;
        //如果没有这个UI加载过，那么执行加载操作，如果有，那么直接执行激活操作
        //load or enable
        return uiitem.GetComponent<T>(); ;
    }


    public void CloseUI<T>(T t,  bool destroy = false) where T : UIBase
    {
        if(destroy)
        {
            Destroy(t.gameObject);
        }
        else
        {
            t.gameObject.SetActive(false);
        }
   
    }




}
