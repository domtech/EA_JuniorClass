using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_TrigBuff))]
public class SEAction_TrigBuffEditor : SEAction_BaseActionEditor
{
    private SEAction_TrigBuff Owner;

    
    private void Awake()
    {
        Owner = (SEAction_TrigBuff)target;
     
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Owner = (SEAction_TrigBuff)target;


   

    }
}
