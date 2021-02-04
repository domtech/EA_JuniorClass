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

        #region �˺��ҽӽ������
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("��Ч�ҽӽ������");
        string socketname = EditorGUILayout.TextField(Owner.SocketName);
        if (socketname != Owner.SocketName)
        {
            Owner.SocketName = socketname;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ��Ч�ֲ�λ��ƫ��
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        Vector3 tmpLocal = EditorGUILayout.Vector3Field("��Ч�ֲ�λ��ƫ��", Owner.OffSet);
        if (tmpLocal != Owner.OffSet)
        {
            Owner.OffSet = tmpLocal;
            EditorUtility.SetDirty(Owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();
        #endregion

        #region ��Ч�ֲ�λ����ת
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        Vector3 tmpLocalRot = EditorGUILayout.Vector3Field("��Ч�ֲ�λ����ת", Owner.OffRot);
        if (tmpLocalRot != Owner.OffRot)
        {
            Owner.OffRot = tmpLocalRot;
            EditorUtility.SetDirty(Owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();
        #endregion



    }


}
