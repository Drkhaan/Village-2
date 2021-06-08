using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonMarche : MonoBehaviour
{
    public float tempsDerniereExecution = 0.0f; // stock le temps passé depuis la derniere execution;
	public float delai;	// tu defini l'interval voulu, en seconde.	

    public List<AudioClip>NomDeLaListe;
    public AudioSource _NomQuOnVeut;
    public bool Marche;
    // Start is called before the first frame update
    void Start()
    {
        delai=Random.Range(0.25f,0.5f);
        _NomQuOnVeut= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)||(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.Z)||Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow)))
        {
            Marche=true;
        }
         if(Input.GetKeyUp(KeyCode.Q)&&(Input.GetKeyUp(KeyCode.D)&&Input.GetKeyUp(KeyCode.S)&&Input.GetKeyUp(KeyCode.Z)&&Input.GetKeyUp(KeyCode.UpArrow)&&Input.GetKeyUp(KeyCode.DownArrow)&&Input.GetKeyUp(KeyCode.LeftArrow)&&Input.GetKeyUp(KeyCode.RightArrow)))
        {
            Marche=false;
            
        }

        if(Marche==true)
        {
           // tempsDerniereExecution+=Time.deltaTime;
        }
        if (tempsDerniereExecution > delai) {
			PlaySoundMarche();
			tempsDerniereExecution = 0;	
         }
    }


    public void PlaySoundMarche()
    {
        Debug.Log("Joue");
        delai=Random.Range(0.25f,0.5f);
        _NomQuOnVeut.clip=NomDeLaListe[Random.Range(0,3)];
        _NomQuOnVeut.PlayOneShot(_NomQuOnVeut.clip);

    }
}
