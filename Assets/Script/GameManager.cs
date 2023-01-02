using Photon.Pun;
using Photon.Realtime;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    // �̱���
    #region �̱���

    private static GameManager Instance = null;
    public static GameManager INSTANCE
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<GameManager>();
            }
            return Instance;
        }
    }
    #endregion

  
    // ���� ��ġ
    [SerializeField] Transform spawnPositionToMaster;
    [SerializeField] Transform spawnPositionToOther;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Spawn();
    }
    
    // �÷��̾� ����
    private void Spawn()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Character", spawnPositionToMaster.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Character", spawnPositionToOther.position, Quaternion.identity);
        }
    }
    // ���� ����
    static public void Quit() 
    {
        Application.Quit();
    }


}

