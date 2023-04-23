using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class BulletBehaviour : NetworkBehaviour
{
     [SerializeField]
     private float bulletSpeed = 20;
     //private int bulletHealth =2;
    // private Tra
   
    Vector3 newDirection;
    Vector3 startPosition;
    public float DrawRayRange = 10.0f;
  //  RaycastHit BulletHitPoint;
  /*  private void Start()
    {
        startPosition = transform.position;
    }*/

    private void Update()
    {
     //   bulletFly();
       //DrawTestRays();


    }

    public override  void FixedUpdateNetwork()
    { 

         transform.Translate(Vector3.right* bulletSpeed * Time.deltaTime);

    }


    private void Awake()
    {
       
    }

    private void bulletFly()
    {
      //  if (bulletHealth == 0) Destroy(gameObject);
   //     Physics.Raycast(transform.position, transform.forward, out BulletHitPoint, 300);
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        /* same by phisycs
            var rb = GetComponent<Rigidbody>();
            rb.velocity = transform.right * bulletSpeed; */
 
    }
    private void OnTriggerEnter(Collider other)
      {
        if (other.tag == "Player")
        {
            //  Debug.Log("We hit player " + other.GetComponent<NetworkObject>().Id);
            if (other.GetComponent<NetworkObject>().Id != this.GetComponent<NetworkObject>().Id)
                Debug.Log("We hit another player");


         //      bulletHealth--;
         //   newDirection = Vector3.Reflect((BulletHitPoint.point - startPosition), BulletHitPoint.normal);
           // transform.rotation = Quaternion.LookRotation(newDirection);
         
        }
      }

 /*   private void DrawTestRays()
    {  //test rays for mirroring bullet
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit))
        {

            Vector3 incomingVec = hit.point - transform.position;
            Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.DrawRay(hit.point, reflectVec, Color.green);

        }
    }*/


    /*  private void OnCollisionEnter(Collision collision)
      {
          Debug.Log("OnCollisionEnter");
          Vector3 direction = Vector3.Reflect(transform.forward, collision.contacts[0].normal);

        //  transform.Translate(direction * bulletSpeed * Time.deltaTime);
      }*/



}
