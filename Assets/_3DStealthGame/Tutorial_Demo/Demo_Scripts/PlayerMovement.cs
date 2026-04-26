using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public GameObject Enemy;

    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readytoJump;
    public KeyCode jumpKey = KeyCode.Space;

    public float playerHeight;
    public LayerMask whatisGround;
    bool isGrounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readytoJump = true;

    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position,Vector3.down,playerHeight * 0.5f + 0.2f, whatisGround);
        MyInput();
        Speedcontrol();

        if(isGrounded)
        {
            rb.linearDamping = groundDrag;
        }

        else
        {
            rb.linearDamping = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput =  Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readytoJump && isGrounded)
        {
            readytoJump = false;

            Jump();
            
            Invoke(nameof(resetJump),jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed *10f, ForceMode.Force);
    
        }
        
        else if(!isGrounded)
        {
             rb.AddForce(moveDirection.normalized * moveSpeed *10f * airMultiplier, ForceMode.Force);
    
        }
    }


    private void Speedcontrol()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x,rb.linearVelocity.y,limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        readytoJump = true;
    }

     private void OnTriggerEnter(Collider other)
     {
        if(other.gameObject.CompareTag("trigger"))
        {
            Instantiate(Enemy);
        }
     }


}