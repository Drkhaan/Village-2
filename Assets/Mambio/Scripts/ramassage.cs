using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ramassage : MonoBehaviour
{

    [SerializeField]
    private Text pickUpText;

    private bool pickUpAllowed;
    // Start is called before the first frame update
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if ( pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        Pickup();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("1");
            pickUpText.gameObject.SetActive(true);
        if (Input.GetKeyDown("e") && collision.tag == "Player")
        {
            pickUpAllowed = true;

        }

            
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void Pickup()
    {
        

        Debug.Log("3");
        Destroy(gameObject);
    }
}
