using UnityEngine;

public class UI_CharacterSelect : UIBase
{
    public Transform ContentInst;

    public int CharacterNumber;

    public CharacterItem ItemTpl;

    protected override void Awake()
    {
        base.Awake();

        //var canvas = gameObject.GetComponent<Canvas>();

        //canvas.sortingOrder = 1;

        for (var i = 0; i< CharacterNumber; i++)
        {
            var item = Instantiate(ItemTpl.gameObject);
            item.SetActive(true);
         
            item.transform.parent = ContentInst;
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            var pos = item.transform.localPosition;
            pos.z = 0f;
            item.transform.localPosition = pos;
            var character = item.GetComponent<CharacterItem>();
            var type = Random.Range(0, 3);
            character.OnStart(type);
        }

        Destroy(ItemTpl.gameObject);
    }


    #region Events
    public void LeaveCharacterSelect()
    {
        UIManager.Inst.CloseUI<UI_CharacterSelect>(this);
    }
    #endregion

}
