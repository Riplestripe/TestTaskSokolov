using UnityEngine;

public class DragObj: Interactble
{
    public bool isDraging;
    private Rigidbody rb;
    [SerializeField] GameObject grabpoint;
  
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            grabpoint = GameObject.FindGameObjectWithTag("DragPoint");
            isDraging = !isDraging;

        }


    }
    private void Update()
    {
        
        if (isDraging)
        {
            float lerpSpeed = 10f;
            rb.useGravity = false;
            rb.freezeRotation = true;
            Vector3 newPos = Vector3.Lerp(transform.position, grabpoint.transform.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(newPos);
            gameObject.layer = 0;
            
           
        }
        else
        {
            rb.useGravity = true;
            rb.freezeRotation = false;
            gameObject.layer = 3;

        }



    }
 

}
