using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUIObserver : MonoBehaviour
{
    [Header("Panels")]
    public GameObject playerDetailsPanel;
    public GameObject sessionBrowserPanel;
    public GameObject createSessionPanel;
    public GameObject statusPanel;

    [Header("Player Settings")]
    public TMP_InputField playerNameInputField;

    [Header("New Game Session")]
    public TMP_InputField sessionNameInputField;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerNickName"))
            playerNameInputField.text = PlayerPrefs.GetString("PlayerNickName");
    }

    void HideAllPanels()
    {
        playerDetailsPanel.SetActive(false);
        sessionBrowserPanel.SetActive(false);
        createSessionPanel.SetActive(false);
        statusPanel.SetActive(false);
}
    public void OnFindGameCliecked()
    {
        PlayerPrefs.SetString("PlayerNickname", playerNameInputField.text);
        PlayerPrefs.Save();

        // SceneManager.LoadScene("(GameLevel1)");

        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        networkRunnerHandler.OnJoinLobby();

        HideAllPanels();

     
        sessionBrowserPanel.gameObject.SetActive(true);
        FindObjectOfType<SessionListScript>(true).OnLookingForSessions();  
    }

    public void OnCreateNewGameClicked()
    {
        HideAllPanels();
        createSessionPanel.SetActive(true);
          
    }

    public void OnStartNewSessionClicked()
    {
        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        networkRunnerHandler.CreateGame(sessionNameInputField.text, "GameLevel1");

        HideAllPanels();

        statusPanel.gameObject.SetActive(true);
    }


    public void OnJoiningServer()
    {
        HideAllPanels();
        statusPanel.gameObject.SetActive(true);
    }

}
