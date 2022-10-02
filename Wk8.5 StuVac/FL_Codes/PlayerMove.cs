using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //movement
    public float speed = 0.1f;



    /*
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

   
    //keybinds
    public KeyCode jumpKey = KeyCode.Space;

    
    public float groundDrag;

    //ground check
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    */

    private Rigidbody rigid;
    public Transform cameraPosition;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3 (xDirection, 0.0f, zDirection);
        moveDirection = cameraPosition.rotation * moveDirection;
        moveDirection.y = 0;

        //Debug.Log(moveDirection.ToString());
        //Debug.Log(moveDirection.normalized.ToString());

        rigid.AddForce (moveDirection.normalized * speed);

        /*
        if(Input.GetKey(jumpKey) && readyToJump)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        */

        /*
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //handle drag
        if (grounded)
            rigid.drag = groundDrag;
        else
            rigid.drag = 0;
        */
                
    }

    /*
    private void Jump()
    {
        rigid.velocity = new Vector3(rigid.velocity.x, 0f, rigid.velocity.z);
        rigid.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        readyToJump = true;
    }
    */

    /*
    private void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rigid.velocity.x, 0f, rigid.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > MoveSpeed)
        {
            Vector3 limited = flatvel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    */
}
