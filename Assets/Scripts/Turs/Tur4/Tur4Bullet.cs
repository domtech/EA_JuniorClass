using UnityEngine;

namespace Tur4
{
    public class Tur4Bullet : MonoBehaviour
    {

        public float FlyDuration;
        public float FlySpeed;

        float StartTime = 0f;
        private void Awake()
        {
            StartTime = Time.time;
        }

        private void Update()
        {
            if(Time.time - StartTime >= FlyDuration)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                transform.position += transform.forward * Time.deltaTime * FlySpeed;
            }
        }
    }
}

