using UnityEngine;

public class FightManager : MonoBehaviour
{

    /*
     * (1) : UI_Login check
     * 
     * (2) : 启动游戏 : 会自动弹（加载）出UI_Login
     * 
     * 点击UI_Login的登录按钮 -> 加载角色和对应的角色UI
     * 
     * */


    UI_Login UILoginInst;
    //加载我们的Login UI
    private void Start()
    {
        //加载login
        //var login = Instantiate(Resources.Load("UI/UI_Login")) as GameObject;

        //UILoginInst = login.GetComponent<UI_Login>();

        UILoginInst = UIManager.Inst.OpenUI<UI_Login>();
    }

    
}
