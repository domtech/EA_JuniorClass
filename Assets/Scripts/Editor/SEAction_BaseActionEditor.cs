using UnityEngine;
using UnityEditor;
using AttTypeDefine;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BaseAction))]
public class SEAction_BaseActionEditor : Editor
{

    string[] options = new string[] {"自动触发","条件触发" };
    private SEAction_BaseAction Owner;


    Rect rect;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Owner = (SEAction_BaseAction)target;

        #region 触发方式: 自动/条件
        EditorGUILayout.Space();
        rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));

        EditorGUILayout.LabelField("触发方式");
        int condition = EditorGUILayout.Popup((int)Owner.TrigType, options);
        if(condition != (int)Owner.TrigType)
        {
            Owner.TrigType = (eTrigType)condition;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region 触发延时
        //Duration
        EditorGUILayout.Space();
        
        float delayTime = EditorGUILayout.FloatField("延时时长", Owner.Duration);

        if(delayTime != Owner.Duration)
        {
            Owner.Duration = delayTime;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        #endregion
    }

}
