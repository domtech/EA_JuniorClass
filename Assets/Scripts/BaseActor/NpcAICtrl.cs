using UnityEngine;
using AttTypeDefine;
public class NpcAICtrl : MonoBehaviour
{

    eStateID npcState = eStateID.eNULL;
    public eStateID NpcState
    {
        get
        {
            return npcState;
        }
        set
        {
            if (value == eStateID.eGetHit)
            {
                // play injure animation.
                Owner.Anim.SetTrigger("Base Layer.GetHit");
                //injure play is over, set state to chase.
            }
            else
            {
                if(value != npcState)
                {

                }
            }
            npcState = value;
        }
    }

    bool IsTrigger = false;

    NpcActor Owner;

    public void OnStart (NpcActor NA)
    {
        Owner = NA;
        IsTrigger = true;
        NpcState = eStateID.eIdle;
    }

    
    private void Update()
    {
        if (!IsTrigger)
            return;

        switch(NpcState)
        {
            case eStateID.eIdle:
                {
                    break;
                }
         
        }
    }



    void EventAnimBegin()
    {

    }


    void EventAnimEnd(int id)
    {
        eStateID ID = (eStateID)id;

        switch(ID)
        {
            case eStateID.eGetHit:
                {
                    NpcState = eStateID.eIdle;
                    break;
                }
        }
    }



}
