using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerMask;
    private PlayerUI playerUI;
    GameObject obj;
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }


   private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            playerUI.UpdateText(string.Empty);
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
            {
                if (hitInfo.collider.CompareTag("Slot"))
                {
                    playerUI.UpdateText("Put cube");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Rigidbody rb = obj.GetComponent<Rigidbody>();
                        obj.GetComponent<DragObj>().isDraging = false;
                        rb.useGravity = false;
                        rb.freezeRotation = true;
                        obj.transform.localPosition = hitInfo.collider.gameObject.transform.position;
                        obj.transform.localEulerAngles = new Vector3(0, 0, 0);
                        obj = null;
                    }
                }

                if (hitInfo.collider.GetComponent<Interactble>() != null)
                {
                    Interactble interactble = hitInfo.collider.GetComponent<Interactble>();
                    playerUI.UpdateText(interactble.promtMessage);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactble.BaseInteract();
                        obj = hitInfo.collider.gameObject;
                    }

                }

            }
            else if (obj == null) return;
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    obj.GetComponent<DragObj>().isDraging = false;
                }
            }
        }
    }
}

    


