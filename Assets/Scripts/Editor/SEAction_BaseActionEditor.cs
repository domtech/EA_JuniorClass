using UnityEngine;
using UnityEditor;
using AttTypeDefine;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BaseAction))]
public class SEAction_BaseActionEditor : Editor
{

    string[] options = new string[] {"�Զ�����","��������" };
    private SEAction_BaseAction Owner;


    Rect rect;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Owner = (SEAction_BaseAction)target;

        #region ������ʽ: �Զ�/����
        EditorGUILayout.Space();
        rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));

        EditorGUILayout.LabelField("������ʽ");
        int condition = EditorGUILayout.Popup((int)Owner.TrigType, options);
        if(condition != (int)Owner.TrigType)
        {
            Owner.TrigType = (eTrigType)condition;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ������ʱ
        //Duration
        EditorGUILayout.Space();
        
        float delayTime = EditorGUILayout.FloatField("��ʱʱ��", Owner.Duration);

        if(delayTime != Owner.Duration)
        {
            Owner.Duration = delayTime;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        #endregion
    }

}
