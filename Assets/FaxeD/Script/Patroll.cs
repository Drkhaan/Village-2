using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : MonoBehaviour
{

    public float Speed;
    private float waitTime;
    public float StartWaitTime;
    public float PosX;
    public float PosY;
    public bool Bouftou;
    public bool Poule;
    public bool MarcheY;
    public bool PeutBouger;
    //public GameObject conversation;

    public Transform[] moveSpots;
    private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        PeutBouger=true;
        waitTime = StartWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        PosX=this.GetComponent<Transform>().position.x;
        PosY=this.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y>PosY&&MarcheY&&PeutBouger)
            {
                        this.GetComponent<Animator>().SetBool("Haut", true);
            }
        if(transform.position.y<PosY&&MarcheY&&PeutBouger)
             {
                         this.GetComponent<Animator>().SetBool("Haut", false);
             }

       /* if(conversation.activeSelf)
        {
            Speed =0f;
        } else 
        {
            Speed =2f;
        }*/

        if(PeutBouger&&moveSpots.Length>0)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Speed * Time.deltaTime);
        }
        

        if(moveSpots.Length>0&&Vector2.Distance(transform.position, moveSpots[randomSpot].position) <0.2f)
        {
            Debug.Log("Rat");
            if(waitTime <=0)
            {
                PosX=this.GetComponent<Transform>().position.x;
                PosY=this.GetComponent<Transform>().position.y;
                if(Bouftou==true)
                {
                    this.GetComponent<Animator>().SetBool("Marche", true);
                }
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = StartWaitTime;
            } else 
            
                {
                      if(Bouftou==true&&PeutBouger)
                {
                    this.GetComponent<Animator>().SetBool("Marche", false);
                }
                    waitTime -= Time.deltaTime;
                    if(transform.position.x>PosX&&Bouftou)
                    {
                        this.GetComponent<SpriteRenderer>().flipX=true;
                    }
                    if(transform.position.x<PosX&&Bouftou)
                    {
                        this.GetComponent<SpriteRenderer>().flipX=false;
                    }

                    if(transform.position.x>PosX&&Poule)
                    {
                        this.GetComponent<SpriteRenderer>().flipX=false;
                    }
                    if(transform.position.x<PosX&&Poule)
                    {
                        this.GetComponent<SpriteRenderer>().flipX=true;
                    }
                }
        }

        //Debug.Log("PosX = "+ PosX+"Position actuel = "+ transform.position.x);
    }

}
