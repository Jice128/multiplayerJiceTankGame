using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class NetworkSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkPlayer playerPrefab;
    CharacterInputObserver _characterInputObserver;
    SessionListScript _sessionListScript;

    CoinsGeneratorScript coinsGeneratorScript;



    public void OnConnectedToServer(NetworkRunner runner) 
    {
        Debug.Log($"OnConnectedToServer");
    }
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player) 
    {
        /*
           for (int i = 0; i < _coinsNumber; i++)
            {
                Debug.Log("CREATE COINS");
                //  Instantiate(_coin, new Vector3(UnityEngine.Random.Range(-8, 8), 1, UnityEngine.Random.Range(-4.5f, 2.45f)), Quaternion.identity);
                runner.Spawn(_coin, new Vector3(UnityEngine.Random.Range(-8, 8), 1, UnityEngine.Random.Range(-4.5f, 2.45f)), Quaternion.identity);
            }
        
         */

        if (runner.IsServer)
        {
            Debug.Log("OnPlayerJoined we are server. Lets spawn player");
            coinsGeneratorScript = FindObjectOfType<CoinsGeneratorScript>();
            runner.Spawn(playerPrefab, Utils.GetRandomSpawnPoint(), Quaternion.Euler(0, -90, 0), player);
            coinsGeneratorScript.PlayersCount++;

        }
        else
        {
            Debug.Log("OnPlayerJoined  WE CLIENT");
           
        }

    }

    private void Awake()
    {
        _sessionListScript = FindObjectOfType<SessionListScript>(true);

    }
    public void OnInput(NetworkRunner runner, NetworkInput input) 
    {
        if (_characterInputObserver == null && NetworkPlayer.Local != null) //if CharacterInputObserver is not assigned yet or networkplayer LOCAL is not null
            _characterInputObserver = NetworkPlayer.Local.GetComponent<CharacterInputObserver>();

        if (_characterInputObserver != null)  //again if it not null so ready to start to be used
        {
            // Debug.Log("_characterInputObserver == null");
            input.Set(_characterInputObserver.GetNetworkInput());
           // Debug.Log(_characterInputObserver.gameObject);
        }
    }
    



    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
  
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { Debug.Log($"OnShutdown"); }
    public void OnDisconnectedFromServer(NetworkRunner runner) { Debug.Log($"OnDisconnectedFromServer"); }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { Debug.Log($"OnConnectRequest"); }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { Debug.Log($"OnConnectFailed"); }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) 
    {

        //will opdate list of sesions when session list UIobserver is active
        if (_sessionListScript == null)
            return;

        if (sessionList.Count == 0)
        {
            Debug.Log("Joined lobby no sessions found");

            _sessionListScript.OnNoSessionFound();
        }
        else
        {
        
            _sessionListScript.ClearList();

            foreach(SessionInfo sessionInfo in sessionList)
            {
                _sessionListScript.AddTolist(sessionInfo);
                Debug.Log($"Foundsession {sessionInfo.Name} playerCount {sessionInfo.PlayerCount}");
            }
        }

    
    }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) 
    
    {
/*
        for (int i = 0; i < _coinsNumber; i++)
        {
            Debug.Log("CREATE COINS");
            //  Instantiate(_coin, new Vector3(UnityEngine.Random.Range(-8, 8), 1, UnityEngine.Random.Range(-4.5f, 2.45f)), Quaternion.identity);
            runner.Spawn(_coin, new Vector3(UnityEngine.Random.Range(-8, 8), 1, UnityEngine.Random.Range(-4.5f, 2.45f)), Quaternion.identity);
        }
*/
    }
    public void OnSceneLoadStart(NetworkRunner runner) { }

}
