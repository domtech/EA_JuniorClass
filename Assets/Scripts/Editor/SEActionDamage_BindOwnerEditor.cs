using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(SEActionDamage_BindOwner))]
public class SEActionDamage_BindOwnerEditor : SEAction_BaseActionEditor
{

    SEActionDamage_BindOwner Owner;
   
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Owner = (SEActionDamage_BindOwner)target;

        #region 伤害挂接结点名称
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("特效挂接结点名称");
        string socketname = EditorGUILayout.TextField(Owner.SocketName);
        if (socketname != Owner.SocketName)
        {
            Owner.SocketName = socketname;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region 特效局部位置偏移
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        Vector3 tmpLocal = EditorGUILayout.Vector3Field("特效局部位置偏移", Owner.OffSet);
        if (tmpLocal != Owner.OffSet)
        {
            Owner.OffSet = tmpLocal;
            EditorUtility.SetDirty(Owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();
        #endregion

        #region 特效局部位置旋转
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        Vector3 tmpLocalRot = EditorGUILayout.Vector3Field("特效局部位置旋转", Owner.OffRot);
        if (tmpLocalRot != Owner.OffRot)
        {
            Owner.OffRot = tmpLocalRot;
            EditorUtility.SetDirty(Owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();
        #endregion



    }


}
