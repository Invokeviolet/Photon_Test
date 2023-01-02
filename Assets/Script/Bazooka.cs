using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bazooka : MonoBehaviourPun
{
    // ����ĳ��Ʈ
    // RaycastHit hit;

    // ���� �Կ��� �ٳ��� �����ϱ�
    [SerializeField] Transform BazookaPoint;

    // �ٳ��� ������
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
            photonView.RPC("Shot", RpcTarget.AllViaServer); // RPC ȣ���� ��û�ϰ� ������ ���� ������ ��� Ŭ���̾�Ʈ���� ��û�Ѵ�.
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
