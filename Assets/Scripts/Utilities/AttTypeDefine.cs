using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace AttTypeDefine
{
    public delegate void NotifySkill();

    public enum eSkillBindType
    {
        eEffectWorld,
        eEffectOwner,
        eDamageOwner,
    }



    public enum ePlayerAttr
    {
        eNULL = -1,
        eHP = 0,
        eAttack = 1,
        eSize = 2,
    }

    public enum StateID { 
        eNULL = -1,
        eGetHit,// ‹…À
        eFlyAway,//ª˜∑…
    }


    public enum ePlayerSide
    {
        ePlayer,
        eEnemy,
        eNPC,
    }
    public enum eTrigType
    {
        eAuto = 0,
        eCondition,
    }

    public enum eSkillType
    {
        eAttack = 0,
        eSkill1,
    }

    public enum eTrigSkillState
    {
        eTrigBegin,
        eTrigEnd,
    }

    public class GameEvent : UnityEvent { };

    public class GameBtnEvent : UnityEvent<PointerEventData> { };

}