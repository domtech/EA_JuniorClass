using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RewriteCoroutine : MonoBehaviour
{
    public Text _uiText;
    static RewriteCoroutine _inst;
    private void Awake()
    {
        _inst = this;
    }

    // Start is called before the first frame update
    public void MyStart()
    {
        var test01 = Test01();
        var test02 = Test02();

        CoroutineManager.Inst.MyStartCoroutine(test01);
        CoroutineManager.Inst.MyStartCoroutine(test02);
    }

    // Update is called once per frame
    void Update()
    {
        CoroutineManager.Inst.UpdateCoroutine();
    }

    static IEnumerator Test01()
    {
        //Debug.Log("start test 01");
        _inst._uiText.text += "start test 01\n\n";
        yield return new IWaitForSeconds(5);
        //Debug.Log("after 5 seconds");
        _inst._uiText.text += "after 5 seconds\n\n";
        yield return new IWaitForSeconds(5);
        //Debug.Log("after 10 seconds");
        _inst._uiText.text += "after 10 seconds\n\nthe end";
    }

    static IEnumerator Test02()
    {
         //Debug.Log("start test 02");
        _inst._uiText.text += "start test 02\n\n";
         yield return new IWaitForFrames(500);
         //Debug.Log("after 500 frames");
        _inst._uiText.text += "after 500 frames\n\n";
    }
}
