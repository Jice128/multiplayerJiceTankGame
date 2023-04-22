using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CoinsGeneratorScript : NetworkBehaviour
{
    public int PlayersCount = 0;
  //  NetworkRunner runner;

    [SerializeField]
    GameObject _coin;
    [SerializeField]
    int _coinsNumber;


    private void Awake()
    {
      //  runner = FindObjectOfType<NetworkRunner>();
    }


    void CoinGenerate()
    {
        for (int i = 0; i < _coinsNumber; i++)
        {
            Debug.Log("CREATE COINS");
            //  Instantiate(_coin, new Vector3(UnityEngine.Random.Range(-8, 8), 1, UnityEngine.Random.Range(-4.5f, 2.45f)), Quaternion.identity);
            Runner.Spawn(_coin, new Vector3(UnityEngine.Random.Range(-8, 8), 1, UnityEngine.Random.Range(-4.5f, 2.45f)), Quaternion.identity);
        }
        PlayersCount = 0;
    }
    private void Update()
    {
        if (PlayersCount == 2)
        {
            CoinGenerate();
            Debug.Log($"we need to spawn coins");
          
        }
       
    }
   
}
