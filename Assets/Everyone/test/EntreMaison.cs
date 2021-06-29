using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreMaison : MonoBehaviour
{
    public Vector3 EntreMaisonPos;
    public GameObject Player;
    public GameObject CamDesactive;
    public GameObject CamActive;
    public GameObject Fade;
    public bool Entre;
    public AudioSource Trans;
    public AudioSource MusicBatiment;
    public AudioSource MusicDehors;
    //public Transform CameraPositionMaison;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {
            Fade.GetComponent<Animator>().SetTrigger("Go");
            Trans.Play();
            Player.transform.position=EntreMaisonPos;
            if(Entre)
            {
                MusicBatiment.Play();
                MusicDehors.Stop();
                CamDesactive.SetActive(false);
                CamActive.SetActive(true);
            }   
            if(!Entre)
            {
                 MusicBatiment.Stop();
                MusicDehors.Play();
                Debug.Log("Rat");
                CamDesactive.SetActive(true);
                CamActive.SetActive(false);
            }   
        }
    }
}
