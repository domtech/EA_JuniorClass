using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BuffSpawnWorld))]
public class SEAction_BuffSpawnWorldEditor : SEAction_BaseActionEditor
{

    SEAction_BuffSpawnWorld Owner;
   
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Owner = (SEAction_BuffSpawnWorld)target;

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

        #region ��ЧScale
        //Duration
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();

        float EffectScale = EditorGUILayout.FloatField(" ��Ч���ű���", Owner.EffectScale);

        if (EffectScale != Owner.EffectScale)
        {
            Owner.EffectScale = EffectScale;
            EditorUtility.SetDirty(Owner.gameObject);
        }
        #endregion


    }


}
