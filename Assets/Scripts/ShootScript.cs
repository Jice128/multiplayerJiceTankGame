using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ShootScript : NetworkBehaviour
{

  
   public GameObject bulletSpawnPosition;

    public bool IsFiring { get; set; }
    public GameObject bulletPrefab;



    public float bulletPower;

   

    public override void FixedUpdateNetwork()
    {
       //getting input from network
       if(GetInput(out NetworkInputData networkInputData))
       {
            if (networkInputData.FireButtonPressed)
            {

           
              //  Debug.Log("networkInputData.FireButtonPressed = " + networkInputData.FireButtonPressed);
               shoot();
            }
        }


    }

    public void shoot()
    {
        Vector3 spawnPosition = bulletSpawnPosition.transform.position ;
      //  Debug.Log("we are spawnBullets");
        //   Runner.LocalPlayer;
        Runner.Spawn(bulletPrefab, spawnPosition, this.transform.localRotation); // this.transform.localRotation
       // bulletPrefab.transform.rotation = this.transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //  Instantiate(Bullet, transform.position, Quaternion.identity);
       //     StartCoroutine(BulletAppear(transform.position));
        }
    }


/*
    private IEnumerator BulletAppear(Vector3 pos)
    {
         Instantiate(bulletPrefab, bulletSpawnPosition.transform.position, transform.rotation);

       // Instantiate(bulletPrefab, pos, Quaternion.identity);

      
        yield return new WaitForSeconds(1);
    }
*/
}
