using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CollectFact collectFact;    
    public Transform fpsCamera;
    public GameObject GameOverUI;

    private bool isDead = false;

    CharacterController charCon;
    public float speed = 10f;
    //gravity
    float ySpeed = 0;
    public float gravity = -80f;

    float pitch = 0f;
      
    [Range(2,10)]
    public float sensitivity;

    [Range(45, 85)]
    public float pitchRange = 45f;

    float xInput = 0f;
    float zInput = 0f;
    float xMouse = 0f;
    float yMouse = 0f;

    void Start()
    {
        charCon = GetComponent<CharacterController>();
        LockCursor();
    }

    void Update()
    {
        if (isDead)
            return;

        GetInput();
        UpdateMovement();
        playSteps();
    }

    void GetInput()
    {        
        xInput = Input.GetAxis("Horizontal") * speed;
        zInput = Input.GetAxis("Vertical") * speed;
        xMouse = Input.GetAxis("Mouse X") * sensitivity;
        yMouse = Input.GetAxis("Mouse Y") * sensitivity;
    }

    void UpdateMovement()
    {        
        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        if (charCon.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = 15f;
            }
            else
            {
                ySpeed = gravity * UnityEngine.Time.deltaTime;
            }
        }
        else
        {
            ySpeed += gravity * UnityEngine.Time.deltaTime;            
        }
        charCon.Move((move + new Vector3(0, ySpeed, 0)) * UnityEngine.Time.deltaTime);        

        transform.Rotate(0, xMouse, 0);
        pitch -= yMouse;
        pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);
        Quaternion camRotation = Quaternion.Euler(pitch, 0, 0);
        fpsCamera.localRotation = camRotation;
    }
    //Collision with a car
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Car")
        {
            Death();
        }
    }
    //Collision with a fact
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fact")
        {
            collectFact.GetComponent<CollectFact>().factCount--;
            other.gameObject.SetActive(false);
        }
    }

    public void Death()
    {
        FindObjectOfType<SoundManager>().StopPlaying("AmbientSound");
        FindObjectOfType<SoundManager>().Play("CrashSound");

        isDead = true;
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
        UnlockCursor();
    }

    void playSteps()
    {
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S) 
            ||Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))       
                FindObjectOfType<SoundManager>().Play("PlayerWalk");
        

        if (Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S) 
            ||Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))        
                FindObjectOfType<SoundManager>().StopPlaying("PlayerWalk");       
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
