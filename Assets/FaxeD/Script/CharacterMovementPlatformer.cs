using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementPlatformer : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public GameObject MapMenu;
    public GameObject conversation;

   
   void Start()
   {
       
   }
   
    void Update()
    {
        if(conversation.activeSelf)
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
}
