using UnityEngine;

public class GlobalHelper
{
    public static GameObject FindGOByName(GameObject target, string targetName)
    {
        if(null == target)
        {
            return null;
        }

        GameObject resultGO = null;

        if(target.name.Equals(targetName) == true)
        {
            return target;
        }

        for(var i = 0; i < target.transform.childCount; i++)
        {
            var child = target.transform.GetChild(i).gameObject;
            if(child.name.Equals(targetName) == true)
            {
                return child;
            }
            else
            {
                if(child.transform.childCount > 0)
                {
                    resultGO = FindGOByName(child, targetName);
                    if(null != resultGO)
                    {
                        return resultGO;
                    }
                }
            }
        }



        return null;
    }


    public static GameObject InstantiateMyPrefab(string path, Vector3 pos, Quaternion rot)
    {

        var obj = Resources.Load(path);

        var go = Object.Instantiate(obj) as GameObject;
        go.name = obj.name;

        go.transform.position = pos;
        go.transform.rotation = rot;
        go.transform.localScale = Vector3.one;

        return go;
    }

   

}
