using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float baseSpeed, shiftSpeed, rotateSpeed;
    public bool walking;
    public Transform playerTrans;

    private float speedMultiplier = 1f;

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement = transform.forward * baseSpeed * speedMultiplier * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = -transform.forward * baseSpeed * speedMultiplier * Time.deltaTime;
        }

        playerRigid.velocity = movement;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("slowrun");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("slowrun");
            playerAnim.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("runbackwards");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("runbackwards");
            playerAnim.SetTrigger("idle");
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (walking)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speedMultiplier = 1.5f; // Increase speed when shift is pressed
                playerAnim.SetTrigger("runforward");
                playerAnim.ResetTrigger("slowrun");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speedMultiplier = 1f; // Reset speed to normal when shift is released
                playerAnim.ResetTrigger("runforward");
                playerAnim.SetTrigger("slowrun");
            }
        }
    }
}
