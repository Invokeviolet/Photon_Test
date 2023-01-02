using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviourPunCallbacks,IPunObservable
{
    float AxisH;
    float AxisV;
    [SerializeField] bool a;
    private void Awake()
    {
        a = false;
    }
    private void Update()
    {
        AxisH = Input.GetAxisRaw("Horizontal"); // GetAxisRaw - 지연시간 없이 움직임
        AxisV = Input.GetAxisRaw("Vertical");

        if (photonView.IsMine)
        {         
            if ((AxisH != 0) || (AxisV != 0))
            {
                transform.Translate(new Vector3(AxisH, 0, AxisV) * Time.deltaTime * 5f);
            }
        }
        
    }

    public void Run() 
    {
    }

    [PunRPC]
    public void Jump() 
    {
        if (a==true)
        {
            a = false;
        }
        else
        {
            a = true;
        }
        Debug.LogError(a);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(a);
        }
        else
        {
            a = (bool)stream.ReceiveNext();
            
        }
        Debug.Log(a);
    }
}
