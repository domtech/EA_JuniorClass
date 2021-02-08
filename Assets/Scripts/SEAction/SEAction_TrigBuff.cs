using UnityEngine;

public class SEAction_TrigBuff : SEAction_BaseAction
{

    private string ConstBuffPath = "Buffs/";
    public string BuffID;

    public override void TrigAction()
    {

        var ae = GetDataStore();

        //实例化buff

        
        var path = GlobalHelper.CombingString(ConstBuffPath, BuffID);

        var obj = Resources.Load(path);

        var buffInst = Instantiate(obj) as GameObject;

        //我们需要一个SEAction_BuffInfo

        //我们需要告诉buff，谁是attacker，谁是defencer

        var buffKinfo = buffInst.GetComponent<SEAction_BuffInfo>();

        //攻击者 ： 也就是这个技能的拥有者
        //防御者 ： 也就是这个技能碰到的合法敌人
        buffKinfo.SetOwner(ae.Owner, ae.Target);

    }
}
