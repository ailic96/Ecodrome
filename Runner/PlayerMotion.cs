using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.00f;

    private float animationDuration = 3.0f;
    private float startTime;

    private bool isDead = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (isDead)
            return;

        if (Time.time - startTime < animationDuration)
        {
            FindObjectOfType<SoundManager>().Play("Running");
            FindObjectOfType<SoundManager>().Play("parkSound");
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed; 
        controller.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed (float modifier)
    {
        speed = 5 + modifier;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((hit.gameObject.tag == "Obstracle") && (hit.point.z > transform.position.z + controller.radius))
            Death();
    }

    private void Death()
    {
        isDead = true;
        FindObjectOfType<SoundManager>().StopPlaying("Running");
        FindObjectOfType<SoundManager>().Play("crashSound");
        GetComponent<Score>().OnDeath();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
