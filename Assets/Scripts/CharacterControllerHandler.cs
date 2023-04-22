using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterControllerHandler : NetworkBehaviour
{
    private NetworkCharacterControllerTank _networkCharacterControllerTank;
    public GameObject bulletPrefab;
   // NetworkRunner runner;
   //coins

    // bool mayCreateCoins = true;

    //how many coins player got
    public int CoinsCount = 0;
    private void Awake()
    {
        _networkCharacterControllerTank = GetComponent<NetworkCharacterControllerTank>();

       
          //check if network runner already inthe scene
            

           
       
    }


    public void spawnBullets()
    {
           Vector3 spawnPosition = this.transform.position;
     
     //   Runner.LocalPlayer;
        Runner.Spawn(bulletPrefab, spawnPosition, this.transform.localRotation); // this.transform.localRotation

      
       

    }

    void Update()
    {
        //works only localy, does not match with network
    }
    public override void FixedUpdateNetwork()
    {

        /* if (Runner.IsClient && Object.IsValid)
         { 

           if(Input.GetKeyDown(KeyCode.Space))
           {
             //  Debug.Log("client shoot");
            //   spawnBullets();
           }

         }*/
        if (Object.HasInputAuthority )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                 Debug.Log("client shoot");
                  spawnBullets();
            }
        }
       

        /*  if (Runner.IsServer)
          {

              if (Input.GetKeyDown(KeyCode.Space))
              {
                  Debug.Log("server shoot");
                  spawnBullets();
              }

          }
        */


        if (GetInput(out NetworkInputData networkInputData))
        {
            _networkCharacterControllerTank.Rotate(networkInputData.RotationInput);

            //  Vector3 _moveDirection = transform.forward * networkInputData.MovementInput.x + 
            Vector3 _moveDirection = transform.right * networkInputData.MovementInput.y;
            _moveDirection.Normalize();
            _networkCharacterControllerTank.Move(_moveDirection);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Coin")
        {
            CoinsCount++;
        }
    }
}
