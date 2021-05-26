using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singe : MonoBehaviour
{
    public Dialogue Dialog;
    public bool Reussi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(Dialog.QueteDonne==true)
        {
            Reussi=true;
            Dialog.QueteTermine=true;
        }
        
    }
}
