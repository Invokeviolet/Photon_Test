using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviourPun
{
    
    // �ڱ� �ڽ��� ������
    Banana bananaPrefab;

    // �ٳ��� �ӵ� & ���ݷ�
    private float BananaSpeed = 10f;
    public float BananaPower = 10f;

    Transform bananaTarget;

    private void Awake()
    {
        bananaPrefab = GetComponent<Banana>();
    }
    private void Start()
    {

    }
    private void Update()
    {        
        photonView.RPC("BananaMove", RpcTarget.All);
    }

    [PunRPC]
    public void BananaMove()
    {
        transform.Translate(Vector3.forward * BananaSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((!photonView.IsMine) && (other.gameObject.CompareTag("Character")))
        {
            Debug.Log("������ ������");
            Destroy(bananaPrefab);           
        }

    }

}
