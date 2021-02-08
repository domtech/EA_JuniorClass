using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BuffTakeDamage))]
public class SEAction_BuffTakeDamageEditor : SEAction_BaseActionEditor
{
    private SEAction_BuffTakeDamage Owner;



    string[] injureAnimNames = new string[] { "受伤", "击飞" };

    private void Awake()
    {
        Owner = (SEAction_BuffTakeDamage)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Owner = (SEAction_BuffTakeDamage)target;


        //show anim type
        #region 播放动画类型
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        var rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));

        EditorGUILayout.LabelField("触发方式");
        int condition = EditorGUILayout.Popup((int)Owner.AnimID, injureAnimNames);
        if (condition != (int)Owner.AnimID)
        {
            Owner.AnimID = (StateID)condition;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion


    }
}
