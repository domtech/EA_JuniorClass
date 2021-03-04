using UnityEngine;

public class UI_CharacterSelect : UIBase
{
    public Transform ContentInst;


    public int CharacterNumber;

    public CharacterItem ItemTpl;

    protected override void Awake()
    {
        base.Awake();
        
        for(var i = 0; i< CharacterNumber; i++)
        {
            var item = Instantiate(ItemTpl.gameObject);
            item.SetActive(true);
         
            item.transform.parent = ContentInst;
            item.transform.localScale = Vector3.one;
            var pos = item.transform.localPosition;
            pos.z = 0f;
            item.transform.localPosition = pos;
        }

        Destroy(ItemTpl.gameObject);

    }



}
