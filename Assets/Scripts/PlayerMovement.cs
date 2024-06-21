using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    PhotonView photon;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        photon = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
      MovePlayer();
        if (!PhotonNetwork.IsMasterClient)
        {
            photon.RPC("MyInput", RpcTarget.MasterClient);
        }

    }

    private void Update()
    {
        MyInput();
        if (!PhotonNetwork.IsMasterClient)
        {
            photon.RPC("MyInput", RpcTarget.MasterClient);
        }
        rb.drag = 5;
    }
    [PunRPC]
    public void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    public void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
