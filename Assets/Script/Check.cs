using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public void OnClickBtn()
    {

        Character[] c = FindObjectsOfType<Character>();
        
        Debug.Log(c.Length);
        
        for(int i = 0; i< c.Length; i++)
        {
            if (c[i].photonView.IsMine == true)
            {
                c[i].Run();
                break;
            }
        }
    }
}
