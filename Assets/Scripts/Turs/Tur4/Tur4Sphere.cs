using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Tur4
{
    public class Tur4Sphere : MonoBehaviour
    {
        bool IsTriggered = false;
        public float DelayMax = 4f;
        public float DelayMin = 1f;
        public GameObject Bullet;

        private Transform PlayerInst;
        public void OnStart(Transform player)
        {
            PlayerInst = player;

            StartCoroutine(WaitToFire());
        }

        IEnumerator WaitToFire()
        {
            while (true)
            {
                var num = Random.Range(0, 101);
                if (num < 30)
                {
                    var dely = Random.Range(DelayMin, DelayMax);
                    yield return new WaitForSeconds(dely);
                    FireBullet();
                }
                else
                    yield return null;
            }
        }

        void FireBullet()
        {
            transform.LookAt(PlayerInst);
            transform.GetComponent<MeshRenderer>().material.DOColor(new Color(
                Random.Range(0f,1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
                ), 1);
            transform.DOShakeScale(1, 1, 3).OnComplete(() =>
            {
                var dir = (PlayerInst.transform.position - transform.position).normalized;
                dir.y = 0f;
                Instantiate(Bullet, transform.position, Quaternion.LookRotation(dir));
            });
           
         
            
        }

        private void Update()
        {
            if (!IsTriggered)
                return;

            if (transform.position.y > 10f)
                Tur4SphereMgr.Inst.Remove(this);

            transform.position += Vector3.up * 2f * Time.deltaTime;

        }

        private void OnTriggerEnter(Collider other)
        {
            StopAllCoroutines();
            transform.DOScale(0.2f, 0.5f).OnComplete(() =>
            {
                IsTriggered = true;

            });

        }

    }
}

