using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : MonoBehaviour
{

    public float Speed;
    private float waitTime;
    public float StartWaitTime;
    public GameObject conversation;

    public Transform[] moveSpots;
    private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = StartWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {

        if(conversation.activeSelf)
        {
            Speed =0f;
        } else 
        {
            Speed =2f;
        }


        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) <0.2f)
        {
            if(waitTime <=0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = StartWaitTime;
            } else 
                {
                    waitTime -= Time.deltaTime;
                }
        }
    }

}
