using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_2_test : MonoBehaviour
{

    private Inventaire inventory;
    public GameObject itemButton;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventaire>();
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("e") && other.tag == "Player")
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    //Instantiate(itemButton, inventory.slots[i].transform , false);
                    Instantiate(itemButton, inventory.slots[i].transform , false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
