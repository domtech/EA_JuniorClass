using UnityEngine;

public class SEAction_Destruction : MonoBehaviour
{
    public float Duration;
    float StarTime = 0f;
    void Start()
    {
        StarTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - StarTime >= Duration)
        {
            Destroy(gameObject);
        }
    }
}
