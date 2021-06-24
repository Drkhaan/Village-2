using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliqueSymbole : MonoBehaviour
{
    public GameObject JournalQuete;
    public GameObject AnimOuvre;
    public AudioSource OpenBook;
    public AudioSource PrendBook; 
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
        StartCoroutine(coroutineA());
    }
    public void AppuieQuitter()
    {
        StartCoroutine(coroutineB());
        JournalQuete.SetActive(false);
    }


     IEnumerator coroutineA()
    {
        AnimOuvre.GetComponent<Animator>().SetBool("OuvreQuete", true);
        PrendBook.Play();
        yield return new WaitForSeconds(1.0f);
        OpenBook.Play();
        yield return new WaitForSeconds(0.6f);
        JournalQuete.SetActive(true);
       
    }

     IEnumerator coroutineB()
    {
        AnimOuvre.GetComponent<Animator>().SetBool("OuvreQuete", false);
        AnimOuvre.GetComponent<Animator>().SetBool("Quitte", true);
         JournalQuete.SetActive(false);
        PrendBook.Play();
        yield return new WaitForSeconds(2.0f);
         AnimOuvre.GetComponent<Animator>().SetBool("Quitte", false);
       
    }


    
}
