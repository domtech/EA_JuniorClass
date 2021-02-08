using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BuffInfo))]
public class SEAction_BuffInfoEditor : SEAction_BaseActionEditor
{
    private SEAction_BuffInfo Owner;

    string[] options2 = new string[] {"��Ч������", "��Ч���Լ�", "�˺����Լ�" };

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
