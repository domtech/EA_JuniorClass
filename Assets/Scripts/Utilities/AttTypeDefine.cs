using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace AttTypeDefine
{
    public delegate void NotifySkill();


    public enum eSkillBindType
    {
        eEffectWorld,
        eEffectOwner,
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