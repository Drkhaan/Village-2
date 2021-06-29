using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutDeMap : MonoBehaviour
{

    public GameObject MorceauDeMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void OnTriggerEnter2D(Collider2D collision)
    {
       if ( collision.tag == "Player")
        {
            Debug.Log("Test");
            Destroy(this.gameObject);
            MorceauDeMap.SetActive(true);
        }
    }
}
