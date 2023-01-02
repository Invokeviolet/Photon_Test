using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    enum SceneInfo
    {
        Lobby,
        Loading,
        InGame
    }

    [SerializeField] TMP_InputField InputNickname;
    [SerializeField] TMP_Text NetworkState;
    [SerializeField] Button JoinButton;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        PhotonNetwork.AutomaticallySyncScene = true; // 다른 플레이어와 동기화
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)SceneInfo.Lobby)
        {
            NetworkState.text = PhotonNetwork.NetworkClientState.ToString();
        }
        // Debug.Log(PhotonNetwork.CountOfPlayers);
    }

    public void JoinedRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = InputNickname.text; // 닉네임 받고
        PhotonNetwork.JoinOrCreateRoom("A", new RoomOptions { MaxPlayers = 2 }, null); // 로비 = null        
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel((int)SceneInfo.Loading); // 안전한 방법
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
            {
                PhotonNetwork.LoadLevel((int)SceneInfo.InGame);
            }
        }
    }

}
