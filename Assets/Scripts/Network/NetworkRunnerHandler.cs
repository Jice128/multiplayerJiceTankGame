using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
using System.Linq;

public class NetworkRunnerHandler : MonoBehaviour
{
    public NetworkRunner networkRunnerPrefab;
    private NetworkRunner _networkRunner; //reference to public network runner from inspector

    private void Awake()
    {  //check if network runner already inthe scene
        NetworkRunner _nerworkRunnerInScene = FindObjectOfType<NetworkRunner>();

        if (_nerworkRunnerInScene != null)
            _nerworkRunnerInScene = _nerworkRunnerInScene;
    }
    void Start()
    {

        if(_networkRunner == null)
        {
        _networkRunner = Instantiate(networkRunnerPrefab); //creating prefab
        _networkRunner.name = "Network runner"; //  //give name
            if(SceneManager.GetActiveScene().name != "MainMenu")
            { 
             //start task for network with our parameters
             Task clientTask = InitializeNetworkRunner(_networkRunner,  GameMode.AutoHostOrClient, "TestSession", NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null );
            }
            Debug.Log($"Server NetworkRunner  is started! "); //check
        }
    }

    protected virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, string sessionName, NetAddress adress, SceneRef scene, Action<NetworkRunner> initialized)
    { 
       
       INetworkSceneManager sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();
       
        if (sceneManager == null)
        {  //chek if the network object  and elready in scene
            sceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }
        // Create the Fusion runner and let it know that we will be providing user input  
        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs
        {
            //gives the parameter to runner
            GameMode = gameMode,
            Address = adress,
            Scene = scene,
            SessionName = sessionName,
            CustomLobbyName = "OurLobbyID ",
            Initialized = initialized,
            SceneManager = sceneManager
        }) ;
    }
    

    public void OnJoinLobby()
    {
        var clientTask = JoinLobby();
    }
    private  async  Task JoinLobby()
    {
        Debug.Log("Join lobby started");

        string lobbyID = "OurLObbyID";

        var result = await _networkRunner.JoinSessionLobby(SessionLobby.Custom, lobbyID);

        if (!result.Ok)
        {
            Debug.LogError($"Unable to join lobby {lobbyID}");
        }
        else
        {
            Debug.Log("Join lobby ok");
        }
    }
 
    public void CreateGame(string sessionName, string sceneName)
    {
        Debug.Log($"Create session {sessionName} scene {sceneName} buil Index {SceneUtility.GetBuildIndexByScenePath($"scenes/{sceneName}")}");
        //join game as a client
        var clientTask = InitializeNetworkRunner(_networkRunner, GameMode.Host, sessionName, NetAddress.Any(), SceneUtility.GetBuildIndexByScenePath($"scenes/{sceneName}"), null);

    }
    public void JoinGame(SessionInfo sessionInfo)
    {
        Debug.Log($"Join session {sessionInfo.Name}");
        //
        var clientTask = InitializeNetworkRunner(_networkRunner, GameMode.Client, sessionInfo.Name, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);

    }

}
