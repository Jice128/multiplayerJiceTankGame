using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
using TMPro;


public class SessionListScript : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public GameObject sessionItemListPref;

    public VerticalLayoutGroup verticalLayGroup;

    private void Awake()
    {
       
        ClearList();
    }

    public void ClearList()
    {// we will delete all children of the vertical layout group

      
        
    
        foreach (Transform child in verticalLayGroup.transform)
        {
          
           Destroy(child.gameObject);
            
        }
      
        statusText.gameObject.SetActive(false);
       

    }

    public void AddTolist(SessionInfo sessionInfo)
    {
        SessionInfoListObserver addedSessionInfoListObserver = Instantiate(sessionItemListPref, verticalLayGroup.transform).GetComponent<SessionInfoListObserver>();
        addedSessionInfoListObserver.SetInformation(sessionInfo);
        //reboot events
        addedSessionInfoListObserver.OnJoinSession += addedSessionInfoListObserver_whenJoinSession;
    }
    private void addedSessionInfoListObserver_whenJoinSession(SessionInfo someSession)
    {
        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();
        networkRunnerHandler.JoinGame(someSession);

        MainMenuUIObserver mainMenuUIObserver = FindObjectOfType<MainMenuUIObserver>();
        mainMenuUIObserver.OnJoiningServer();

    }

    public void OnNoSessionFound()
    {
        ClearList();

        statusText.text = "There is no game session found";
        statusText.gameObject.SetActive(true);
    }

    public void OnLookingForSessions()
    {
        ClearList();

        statusText.text = "Looking for game sessions";
        statusText.gameObject.SetActive(true);
    }

}
