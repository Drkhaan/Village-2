using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
        new Rigidbody2D rigidbody2D;

    public float movementSpeed = 1000.0f;
    public GameObject DialogueCanvas;
    public bool canMove;
    public bool DansZoneDialog;
    public bool Entraindeparler;

    void Awake()
    {
        canMove=true;
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        if(canMove)
        {
             Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        MoveF(targetVelocity);
        }

        if(DansZoneDialog==true&&Input.GetKey(KeyCode.E))
        {
            DialogueCanvas.SetActive(true);
            canMove=false;
            Entraindeparler=true;
        }
       
    }

    void MoveF(Vector2 targetVelocity)
    {        
        // Set rigidbody velocity
        rigidbody2D.velocity = (targetVelocity * movementSpeed) * Time.deltaTime; // Multiply the target by deltaTime to make movement speed consistent across different framerates
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Dialog")
        {
            DansZoneDialog=true;
        }

    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Dialog")
        {
            DansZoneDialog=false;
        }

    }
}

