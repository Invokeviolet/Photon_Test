using Photon.Pun;
using Photon.Realtime;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    // ½Ì±ÛÅæ
    #region ½Ì±ÛÅæ

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

  
    // ½ºÆù À§Ä¡
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
    
    // ÇÃ·¹ÀÌ¾î »ý¼º
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
    // °ÔÀÓ Á¾·á
    static public void Quit() 
    {
        Application.Quit();
    }


}

