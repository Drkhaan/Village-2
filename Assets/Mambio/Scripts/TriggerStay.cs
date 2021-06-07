using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStay : MonoBehaviour
{
    public GameObject passage;

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Player")
       {
           passage.SetActive(true);
       Debug.Log("INOXTAG");
       }
       
   }

   void OnTriggerExit2d(Collider2D other)
   {
       if(other.tag == "Player")
        {
            passage.SetActive(false);
        }
   }
}
