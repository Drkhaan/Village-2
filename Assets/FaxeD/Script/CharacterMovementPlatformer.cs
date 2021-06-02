using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementPlatformer : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public GameObject MapMenu;
    //public GameObject conversation;
    public GameObject prenom;

   
   void Start()
   {
       
   }
   
    void Update()
    {
        /*if(conversation.activeSelf)
        {
            speed =0f;
        } else 
        {
            speed =5f;
        }*/

         if(prenom.activeSelf)
        {
            speed =0f;
        } else 
        {
            speed =5f;
        }
       
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 move = rb2d.velocity;
        move.x = x * speed;
         move.y = y * speed;

        rb2d.velocity = move;


        if(Input.GetKeyDown(KeyCode.Tab))
        {
            MapMenu.SetActive(true);
        }
    }

    public void SavePlayer()
    {
        save.SavePlayer(this);
    }

    public void LoadPlayer()
    {
       PlayerData data = save.LoadPlayer();

       Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }
}
