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

    public List<AudioSource> sonsPNJ = new List<AudioSource>();
    public float numeroPNJ; 

    //trucs rajoutés par moi et ossatte
    public GameObject mapMenu;
    public GameObject prenom;
    //fin trucs


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
        //trucs rajoutés encore

        if ( Input.GetKeyDown(KeyCode.Tab))
        {
            mapMenu.SetActive(true);
        }
       
        
        if ( prenom.activeSelf )
        {
            movementSpeed = 0;

        } else 
        {
            movementSpeed = 350;
        }

        if ( mapMenu.activeSelf )
        {
            movementSpeed = 0;
            
        } else
        {
            movementSpeed = 350f;
        }
        
        // fin des trucs rajoutés


        if(canMove)
        {
             Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        MoveF(targetVelocity);
        }

        if(DansZoneDialog==true&&Input.GetKey(KeyCode.E))
        {
            this.GetComponentInChildren<Rigidbody2D>().velocity=new Vector2(0,0);
            DialogueCanvas.SetActive(true);
            canMove=false;
            Entraindeparler=true;

            if ( numeroPNJ == 1 )
            {
                sonsPNJ[ 0 ].Play();
            }
            if ( numeroPNJ == 2 )
            {
                sonsPNJ[ 1 ].Play();
            }
            if ( numeroPNJ == 3 )
            {
                sonsPNJ[ 2 ].Play();
            }
            if ( numeroPNJ == 4 )
            {
                sonsPNJ[ 3 ].Play();
            }
            if ( numeroPNJ == 5 )
            {
                sonsPNJ[ 4 ].Play();
            }
            if ( numeroPNJ == 6 )
            {
                sonsPNJ[ 5 ].Play();
            }
            if ( numeroPNJ == 7 )
            {
                sonsPNJ[ 6 ].Play();
            }

        }

        /*if(canMove&&Input.GetKeyDown(KeyCode.LeftArrow)||canMove&&Input.GetKeyDown(KeyCode.Z)){
            this.GetComponentInChildren<SpriteRenderer>().flipX=true;
        }
        if(canMove&&Input.GetKeyDown(KeyCode.RightArrow)||canMove&&Input.GetKeyDown(KeyCode.D)){
            this.GetComponentInChildren<SpriteRenderer>().flipX=false;
        }*/

        if(canMove&&Input.GetKeyDown(KeyCode.Q)||canMove&&Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
            //this.GetComponent<SpriteRenderer>().flipX=false;
            this.GetComponent<Animator>().SetBool("CoteGauche", true);
            this.GetComponent<Animator>().SetBool("Descend", false);
        }
        if(canMove&&Input.GetKeyDown(KeyCode.D)||canMove&&Input.GetKeyDown(KeyCode.RightArrow))
        {

           this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);

            this.GetComponent<Animator>().SetBool("CoteDroit", true);
            this.GetComponent<Animator>().SetBool("Descend", false);
        }
        if(canMove&&Input.GetKeyDown(KeyCode.Z)||canMove&&Input.GetKeyDown(KeyCode.UpArrow))
        {

            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);

            this.GetComponent<Animator>().SetBool("Dos", true);
            this.GetComponent<Animator>().SetBool("CoteGauche", false);
            this.GetComponent<Animator>().SetBool("Descend", false);
        }
        if(canMove&&Input.GetKeyDown(KeyCode.S)||canMove&&Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("Descend", true);
           this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
        }
        if(Input.GetKeyUp(KeyCode.Q)||Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.GetComponent<Animator>().SetBool("CoteGauche", false);
           this.GetComponent<Animator>().SetBool("NormalGauche", true);
            this.GetComponent<Animator>().SetBool("Descend", false);
        }
        if(Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.GetComponent<Animator>().SetBool("NormalDroite", true);
            this.GetComponent<Animator>().SetBool("CoteDroit", false);
           // this.GetComponent<Animator>().SetBool("Descend", false);
            //this.GetComponent<SpriteRenderer>().flipX=false;
        }
        if(Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.GetComponent<Animator>().SetBool("NormalBas", true);
            this.GetComponent<Animator>().SetBool("Descend", false);
        }
        if(Input.GetKeyUp(KeyCode.Z)||Input.GetKeyUp(KeyCode.UpArrow))
        {
            //this.GetComponent<SpriteRenderer>().flipX=false;
            this.GetComponent<Animator>().SetBool("Dos", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", true);
        }

        if(canMove&&Input.GetKeyDown(KeyCode.S)&&Input.GetKeyDown(KeyCode.Q)||canMove&&Input.GetKeyDown(KeyCode.DownArrow)&&Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //this.GetComponent<SpriteRenderer>().flipX=false;
            this.GetComponent<Animator>().SetBool("Descend", true);
            this.GetComponent<Animator>().SetBool("CoteGauche", false);
            this.GetComponent<Animator>().SetBool("CoteDroit", false);
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
        }
        if(canMove&&Input.GetKeyDown(KeyCode.S)&&Input.GetKeyDown(KeyCode.D)||canMove&&Input.GetKeyDown(KeyCode.DownArrow)&&Input.GetKeyDown(KeyCode.RightArrow))
        {
           this.GetComponent<Animator>().SetBool("CoteGauche", false);
            this.GetComponent<Animator>().SetBool("Descend", true);
            this.GetComponent<Animator>().SetBool("CoteGauche", false);
            this.GetComponent<Animator>().SetBool("CoteDroit", false);
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
        }

        if(canMove&&Input.GetKeyDown(KeyCode.Z)&&Input.GetKeyDown(KeyCode.Q)||canMove&&Input.GetKeyDown(KeyCode.UpArrow)&&Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //this.GetComponent<SpriteRenderer>().flipX=false;
            this.GetComponent<Animator>().SetBool("Dos", true);
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
        }
        if(canMove&&Input.GetKeyDown(KeyCode.Z)&&Input.GetKeyDown(KeyCode.D)||canMove&&Input.GetKeyDown(KeyCode.UpArrow)&&Input.GetKeyDown(KeyCode.RightArrow))
        {
           // this.GetComponent<SpriteRenderer>().flipX=false;
            this.GetComponent<Animator>().SetBool("Dos", true);
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
        }
        if(canMove&&Input.GetKeyDown(KeyCode.Z)&&Input.GetKeyUp(KeyCode.Q)||canMove&&Input.GetKeyDown(KeyCode.UpArrow)&&Input.GetKeyUp(KeyCode.LeftArrow))
        {
           // this.GetComponent<SpriteRenderer>().flipX=false;
            this.GetComponent<Animator>().SetBool("Dos", true);
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
        }
        if(canMove&&Input.GetKeyDown(KeyCode.S)&&Input.GetKeyUp(KeyCode.Q)||canMove&&Input.GetKeyDown(KeyCode.DownArrow)&&Input.GetKeyUp(KeyCode.LeftArrow))
        {
           // this.GetComponent<SpriteRenderer>().flipX=false;
            this.GetComponent<Animator>().SetBool("Descend", true);
            this.GetComponent<Animator>().SetBool("Dos", false);
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
        }
        if(canMove&&Input.GetKeyDown(KeyCode.S)&&Input.GetKeyUp(KeyCode.D)||canMove&&Input.GetKeyDown(KeyCode.DownArrow)&&Input.GetKeyUp(KeyCode.RightArrow))
        {
           // this.GetComponent<SpriteRenderer>().flipX=false;
            this.GetComponent<Animator>().SetBool("Descend", true);
            this.GetComponent<Animator>().SetBool("Dos", false);
            this.GetComponent<Animator>().SetBool("NormalGauche", false);
            this.GetComponent<Animator>().SetBool("NormalDroite", false);
            this.GetComponent<Animator>().SetBool("NormalHaut", false);
            this.GetComponent<Animator>().SetBool("NormalBas", false);
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

