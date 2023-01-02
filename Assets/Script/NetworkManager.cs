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
        PhotonNetwork.AutomaticallySyncScene = true; // �ٸ� �÷��̾�� ����ȭ
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
        PhotonNetwork.LocalPlayer.NickName = InputNickname.text; // �г��� �ް�
        PhotonNetwork.JoinOrCreateRoom("A", new RoomOptions { MaxPlayers = 2 }, null); // �κ� = null        
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel((int)SceneInfo.Loading); // ������ ���
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
