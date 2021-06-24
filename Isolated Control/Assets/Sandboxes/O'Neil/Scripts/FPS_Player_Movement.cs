using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Player_Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public bool canDoubleJump = false;
    public bool doubleJump;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public float jumpGrace = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        jumpGrace -= Time.fixedDeltaTime;
        Collider[] cols = new Collider[1];
        cols = Physics.OverlapSphere(groundCheck.position, groundDistance, groundMask);

        if (cols != null && cols.Length > 0 && cols[0] != null)
        {
            isGrounded = true;
            jumpGrace = 0.1f;

            //Moving Platform Stuff
            if (cols[0].attachedRigidbody != null)
            {
                controller.Move(cols[0].attachedRigidbody.velocity * Time.fixedDeltaTime);
            }
        }
        else isGrounded = false;

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            doubleJump = true;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.fixedDeltaTime);

        velocity.y += gravity * Time.fixedDeltaTime;

        controller.Move(velocity * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpGrace > 0))
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && doubleJump == true && isGrounded == false && canDoubleJump == true)
        {
            Jump();
            doubleJump = false;
        }
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        jumpGrace = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DoubleJumpEnable")
        {
            canDoubleJump = true;
            Debug.Log("DoubleJumpEnable");
        }
    }

}
