using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Fusion;
using System;

public class SessionInfoListObserver : MonoBehaviour
{
    public TextMeshProUGUI sessionNameText;
    public TextMeshProUGUI playerCountText;
    public Button joinButton;


     SessionInfo _sessionInfo;

    
    public event Action <SessionInfo> OnJoinSession;

    public void SetInformation(SessionInfo sessionInfo)
    {
        this._sessionInfo = sessionInfo;

        sessionNameText.text = sessionInfo.Name;
        Debug.Log("Sessioon Info " + sessionInfo.IsValid);
        playerCountText.text = $"{sessionInfo.PlayerCount.ToString()}/{sessionInfo.MaxPlayers.ToString()}";

        bool isJoinButtonActive = true;

        if(sessionInfo.PlayerCount >= sessionInfo.MaxPlayers)
        {
            isJoinButtonActive = false;
        }

        joinButton.gameObject.SetActive(isJoinButtonActive);
            
    }

    public void OnClick()
    {
        OnJoinSession?.Invoke(_sessionInfo);

    }
}
