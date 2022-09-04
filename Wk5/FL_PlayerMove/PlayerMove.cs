using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    public float speed = 0.1f;

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
        Debug.Log(moveDirection.ToString());
        Debug.Log(moveDirection.normalized.ToString());
        rigid.AddForce (moveDirection.normalized * speed);

    }

}
