using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject client;

    private void Start()
    {
        if(!PhotonNetwork.IsMasterClient)    
      PhotonNetwork.Instantiate(player.name, new Vector3(0, 0.5f, 0), Quaternion.identity);

            
           
        
    }
}
