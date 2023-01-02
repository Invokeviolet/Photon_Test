using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bazooka : MonoBehaviourPun
{
    // 레이캐스트
    // RaycastHit hit;

    // 무기 입에서 바나나 생성하기
    [SerializeField] Transform BazookaPoint;

    // 바나나 프리팹
    [SerializeField] Banana bananaPrefab;


    private void Awake()
    {

    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (!photonView.IsMine) return;

        // bool fire = Input.GetMouseButton(0);
        if (Input.GetMouseButtonDown(0))
        {            
            photonView.RPC("Shot", RpcTarget.AllViaServer); // RPC 호출을 요청하고 서버가 나를 포함한 모든 클라이언트에게 요청한다.
        }
        /*if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) //touchPlaneLayerMask
        {
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }*/
    }

    Banana banana;
    [PunRPC]
    private void Shot()
    {
        banana = Instantiate(bananaPrefab, transform.position, Quaternion.identity);
        
        /*if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Banana", transform.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Banana", transform.position, Quaternion.identity);
        }*/

    }
}
