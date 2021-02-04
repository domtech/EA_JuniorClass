using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_SkillInfo))]
public class SEAction_SkillInfoEditor : SEAction_BaseActionEditor
{
    private SEAction_SkillInfo Owner;

    string[] options2 = new string[] {"��Ч������", "��Ч���Լ�" };


    private void Awake()
    {
        Owner = (SEAction_SkillInfo)target;
        Owner.ObjName = "";
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Owner = (SEAction_SkillInfo)target;


        #region ������Ϸ��������ͺ�����

        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();

        Rect rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(50));

        EditorGUILayout.LabelField("�½��ű�������");

        int SkillBindType =  EditorGUILayout.Popup((int)Owner.SkillBindType, options2);

        if(SkillBindType != (int)Owner.SkillBindType)
        {
            Owner.SkillBindType = (eSkillBindType)SkillBindType;
            EditorUtility.SetDirty(Owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();


        rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));
        EditorGUILayout.LabelField("�½��ű�����");
        string ObjName = EditorGUILayout.TextField(Owner.ObjName);
        if(false == Owner.ObjName.Equals(ObjName))
        {
            Owner.ObjName = ObjName;
            EditorUtility.SetDirty(Owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();
        #endregion


        #region ȷ�ϰ�ť
        EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        if(GUILayout.Button("������Ϸ����"))
        {
            GameObject obj = new GameObject(Owner.ObjName);
            obj.transform.parent = Owner.gameObject.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;

            obj.AddComponent<SEAction_DataStore>();

            switch(Owner.SkillBindType)
            {
                case eSkillBindType.eEffectOwner:
                    {
                        break;
                    }
                case eSkillBindType.eEffectWorld:
                    {
                        obj.AddComponent<SEAction_SpawnWorld>();
                        break;
                    }
            }
        }
        EditorGUILayout.EndHorizontal();

        #endregion


    }
}
