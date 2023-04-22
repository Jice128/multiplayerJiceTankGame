using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CoinBehaviorScript : NetworkBehaviour
{
    [SerializeField]
    float rotationSpeed;
  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }


}
