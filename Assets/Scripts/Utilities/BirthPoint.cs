using UnityEngine;
using AttTypeDefine;

public class BirthPoint : MonoBehaviour
{
    public ePlayerSide PlayerSide = ePlayerSide.ePlayer;

    public float Scale;
    private void OnDrawGizmos()
    {
        Color c = Color.red;
        switch(PlayerSide)
        {
            case ePlayerSide.ePlayer:
                {
                    c = Color.green;
                    break;
                }
            case ePlayerSide.eNPC:
                {
                    c = Color.blue;
                    break;
                }
            case ePlayerSide.eEnemy:
                {
                    c = Color.red;
                    break;
                }
        }

        Gizmos.color = c;

        Gizmos.DrawSphere(transform.position, 0.5f);
    }

}
