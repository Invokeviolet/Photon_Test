using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform spawnPositionToMaster;
    [SerializeField] Transform spawnPositionToOther;

    private void Start()
    {
        Spawn();
    }
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
}
