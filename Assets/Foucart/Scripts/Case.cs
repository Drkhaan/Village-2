using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public GameObject Cameraa;
    public bool Gauche;
    public bool Droite;
    public bool Haut;
    public bool Bas;
    public bool HautOk;
    public bool DroiteOk;
    public bool GaucheOk;
    public bool BasOk;
    public float speed;
    public Transform newPosHaut;
    public Transform newPosBas;
    public Transform newPosGauche;
    public Transform newPosDroite;

    
    // Start is called before the first frame update
    void Start()
    {
         speed=15;
    }

    // Update is called once per frame
    void Update()
    {
         if(HautOk==true)
         {
              Cameraa.transform.position = Vector3.MoveTowards(Cameraa.transform.position,new Vector3(Cameraa.transform.position.x,newPosHaut.position.y,Cameraa.transform.position.z), speed * Time.deltaTime);
         }
         if(BasOk==true)
         {
              Cameraa.transform.position = Vector3.MoveTowards(Cameraa.transform.position,new Vector3( Cameraa.transform.position.x,newPosBas.position.y, Cameraa.transform.position.z), speed * Time.deltaTime);
         }
         if(DroiteOk==true)
         {
              Cameraa.transform.position = Vector3.MoveTowards(Cameraa.transform.position,new Vector3(newPosDroite.position.x,Cameraa.transform.position.y,Cameraa.transform.position.z), speed * Time.deltaTime);
         }
         if(GaucheOk==true)
         {
              Cameraa.transform.position = Vector3.MoveTowards(Cameraa.transform.position,new Vector3(newPosGauche.position.x,Cameraa.transform.position.y,Cameraa.transform.position.z), speed * Time.deltaTime);
         }
         if(Cameraa.transform.position==new Vector3(newPosHaut.position.x,newPosHaut.position.y,newPosHaut.position.z))
         {
             HautOk=false;
         }
         if(Cameraa.transform.position==new Vector3(newPosBas.position.x,newPosBas.position.y,newPosBas.position.z))
         {
             BasOk=false;
         }
         if(Cameraa.transform.position==new Vector3(newPosGauche.position.x,newPosGauche.position.y,newPosGauche.position.z))
         {

             GaucheOk=false;
         }
         if(Cameraa.transform.position==new Vector3(newPosDroite.position.x,newPosDroite.position.y,newPosDroite.position.z))
         {
             DroiteOk=false;
         }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {
            if(Haut==true)
            {
                BasOk=false;
            GaucheOk=false;
            DroiteOk=false;
                HautOk=true;
                StartCoroutine(coroutineA());
            }
            if(Bas==true)
            {
                GaucheOk=false;
            DroiteOk=false;
                HautOk=false;
                BasOk=true;
                StartCoroutine(coroutineA());
            }
            if(Gauche==true)
            {
                HautOk=false;
            BasOk=false;
                 DroiteOk=false;
                GaucheOk=true;
                StartCoroutine(coroutineA());
            }
            if(Droite==true)
            {
                HautOk=false;
            BasOk=false;
            GaucheOk=false;
                DroiteOk=true;
                StartCoroutine(coroutineA());
            }





        }
    }

    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(1f);
        HautOk=false;
        BasOk=false;
        GaucheOk=false;
        DroiteOk=false;

       
    }
}
