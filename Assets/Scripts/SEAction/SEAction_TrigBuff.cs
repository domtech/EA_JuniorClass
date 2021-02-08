using UnityEngine;

public class SEAction_TrigBuff : SEAction_BaseAction
{

    private string ConstBuffPath = "Buffs/";
    public string BuffID;

    public override void TrigAction()
    {

        var ae = GetDataStore();

        //ʵ����buff

        
        var path = GlobalHelper.CombingString(ConstBuffPath, BuffID);

        var obj = Resources.Load(path);

        var buffInst = Instantiate(obj) as GameObject;

        //������Ҫһ��SEAction_BuffInfo

        //������Ҫ����buff��˭��attacker��˭��defencer

        var buffKinfo = buffInst.GetComponent<SEAction_BuffInfo>();

        //������ �� Ҳ����������ܵ�ӵ����
        //������ �� Ҳ����������������ĺϷ�����
        buffKinfo.SetOwner(ae.Owner, ae.Target);

    }
}
