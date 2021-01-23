using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tur4SphereMgr : MonoBehaviour
{
    public Vector3 AreaSize;

    public int BirthNumber;

    List<Tur4Sphere> list;

    public GameObject SpherePrefab;

    static private Tur4SphereMgr _Inst;
    static public Tur4SphereMgr Inst => (_Inst);

    private void Awake()
    {
        _Inst = this;
        list = new List<Tur4Sphere>();

        for(var i = 0; i < BirthNumber; i++)
        {
            Add(CreateRandomSphere());
        }

    }

    Tur4Sphere CreateRandomSphere()
    {
        var pos = transform.position + 0.5f*new Vector3(
                                            Random.Range(AreaSize.x*-1f, AreaSize.x),
                                            Random.Range(AreaSize.y * -1f, AreaSize.y),
                                            Random.Range(AreaSize.z * -1f, AreaSize.z)
                                         );

        var sphere = Instantiate(SpherePrefab, pos, Quaternion.identity);

        return sphere.GetComponent<Tur4Sphere>();
    }

    void Add (Tur4Sphere obj)
    {
        list.Add(obj);
    }

    public void Remove(Tur4Sphere obj)
    {
        if(list.Contains(obj))
        {
            list.Remove(obj);
            Destroy(obj);

            //create

        }
    }

    public void ClearAll()
    {
        while(list.Count > 0)
        {
            var tmp = list[0];
            list.Remove(tmp);
            Destroy(tmp.gameObject);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, AreaSize);
    }






}
