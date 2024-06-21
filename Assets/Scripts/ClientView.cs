using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientView : MonoBehaviour
{
    public GameObject cam;
    PhotonView photon;
    private void Start()
    {
        photon = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (cam == null)
        {
            cam = GameObject.FindGameObjectWithTag("Player");

        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
        }
    }

    [PunRPC]
    public void MovePlayer()
    {
        
    }

}
