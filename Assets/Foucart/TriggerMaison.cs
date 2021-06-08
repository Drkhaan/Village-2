using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMaison : MonoBehaviour
{
    public Vector3 PositionEntre;
    public GameObject Player;
    public AudioSource Entre;
    public GameObject Fade;
    public GameObject Cam;
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
            StartCoroutine(coroutineA());
        }
    }



    IEnumerator coroutineA()
    {
        Cam.GetComponent<CamFollow>().PeutFollow=false;
        Entre.Play();
        Player.GetComponent<SpriteRenderer>().enabled=false;
        Player.GetComponent<Move>().canMove=false;
         Player.GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
        Fade.GetComponent<Animator>().SetBool("Go", true);
        yield return new WaitForSeconds(2f);
        Player.transform.position=PositionEntre;
        Fade.GetComponent<Animator>().SetBool("Enleve", true);
        Fade.GetComponent<Animator>().SetBool("Go", false);
        Player.GetComponent<Move>().canMove=true;
        Player.GetComponent<SpriteRenderer>().enabled=true;
        Cam.GetComponent<CamFollow>().PeutFollow=true;
        yield return new WaitForSeconds(1.5f);
        Fade.GetComponent<Animator>().SetBool("Enleve", false);
       
    }
}
