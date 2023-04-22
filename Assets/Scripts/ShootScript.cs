using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawnPosition;
    public float bulletPower;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //  Instantiate(Bullet, transform.position, Quaternion.identity);
            StartCoroutine(BulletAppear(transform.position));
        }
    }


    private IEnumerator BulletAppear(Vector3 pos)
    {
         Instantiate(bulletPrefab, bulletSpawnPosition.transform.position, transform.rotation);

       // Instantiate(bulletPrefab, pos, Quaternion.identity);

      
        yield return new WaitForSeconds(1);
    }

}
