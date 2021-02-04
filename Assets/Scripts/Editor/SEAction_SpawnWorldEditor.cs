using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_SpawnWorld))]
public class SEAction_SpawnWorldEditor : SEAction_BaseActionEditor
{

    SEAction_SpawnWorld Owner;
   
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Owner = (SEAction_SpawnWorld)target;

        #region ��Чʵ������

        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("��Чʵ������");

        var tmpEffect = EditorGUILayout.ObjectField((Object)Owner.EffectSpawnInst, typeof(GameObject), false) as GameObject;

        if(tmpEffect != Owner.EffectSpawnInst)
        {
            Owner.EffectSpawnInst = tmpEffect;
            EditorUtility.SetDirty(Owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();

        #endregion

        #region ��Ч�ҽӽ������
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("��Ч�ҽӽ������");
        string socketname = EditorGUILayout.TextField(Owner.SocketName);
        if(socketname != Owner.SocketName)
        {
            Owner.SocketName = socketname;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ��Ч������ʱʱ��
        //Duration
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();

        float delayTime = EditorGUILayout.FloatField(" ��Ч������ʱʱ��", Owner.EffectDestroyDelay);

        if (delayTime != Owner.EffectDestroyDelay)
        {
            Owner.EffectDestroyDelay = delayTime;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        #endregion

        #region ��Ч�ֲ�λ��ƫ��
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        Vector3 tmpLocal = EditorGUILayout.Vector3Field("��Ч�ֲ�λ��ƫ��", Owner.OffSet);
        if(tmpLocal != Owner.OffSet)
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
