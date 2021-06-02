using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliqueSymbole : MonoBehaviour
{
    public GameObject JournalQuete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AppuieSymbole()
    {
        JournalQuete.SetActive(true);
    }
    public void AppuieQuitter()
    {
        JournalQuete.SetActive(false);
    }
}
