using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BuffInfo))]
public class SEAction_BuffInfoEditor : SEAction_BaseActionEditor
{
    private SEAction_BuffInfo Owner;

    string[] options2 = new string[] {"特效绑定世界", "特效绑定自己", "伤害绑定自己" };

    private void Awake()
    {
        Owner = (SEAction_BuffInfo)target;
  
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Owner = (SEAction_BuffInfo)target;
    }
}
