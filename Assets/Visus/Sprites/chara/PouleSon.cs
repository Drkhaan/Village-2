using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouleSon : MonoBehaviour
{
    public bool PeutSon;
    public AudioSource Poule;
    private bool Une;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"&&PeutSon)
        {
            Debug.Log("A");;
            Poule.volume=0.1f;
        }
        if(other.tag=="Player"&&PeutSon&&!Une)
        {
            Une=true;
            Poule.Play();
            Debug.Log("A");;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"&&PeutSon)
        {
            Poule.volume=0f;
        }
    }
}
