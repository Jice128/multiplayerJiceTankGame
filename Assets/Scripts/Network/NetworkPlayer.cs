using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;


public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
   public static NetworkPlayer Local { get; set; }

  

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            Local = this;
            Debug.Log("local player is spawned!");
        }
        else Debug.Log("spawned remote player");
    }

    public void PlayerLeft(PlayerRef player)
    {
        if (player == Object.InputAuthority) //mean that we are local player
            Runner.Despawn(Object);
    }
  
}
