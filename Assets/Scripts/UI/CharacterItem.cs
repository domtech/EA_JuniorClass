using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItem : MonoBehaviour
{

    public GameObject[] BGArray;
 

    void SetBGState(int type)
    {

        for(var i = 0; i < 3; i++)
        {
            if(type == i)
            {
                BGArray[i].SetActive(true);
            }
            else
            {
                BGArray[i].SetActive(false);
            }
        }

       
    }

    public void OnStart (int type)
    {
        SetBGState(type);
    }
}
