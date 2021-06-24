using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosCam : MonoBehaviour
{
    public Transform Tran;
    public float speed;
    public GameObject Cameraa;
    public bool MoveCam;
    public float SizeMax;
    public float SizeNormal;
    // Start is called before the first frame update
    void Start()
    {
        speed=5;
        SizeMax=6.5f;
        SizeNormal=4;
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveCam==true)
        {
            if(Cameraa.GetComponent<Camera>().orthographicSize<SizeMax)
            {
                Cameraa.GetComponent<Camera>().orthographicSize+=1*Time.deltaTime;
                Cameraa.transform.position = Vector3.MoveTowards(Cameraa.transform.position,Tran.position, speed * Time.deltaTime);
            }
             
        }
        if(MoveCam==false)
        {
            if(Cameraa.GetComponent<Camera>().orthographicSize>SizeNormal)
            {
                Cameraa.GetComponent<Camera>().orthographicSize-=3*Time.deltaTime;
                 Cameraa.GetComponent<CamFollow>().enabled=true;
                 Cameraa.transform.position=new Vector3(Cameraa.transform.position.x,0,-10);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {
            Debug.Log("OUAI");
            Cameraa.GetComponent<CamFollow>().enabled=false;
            MoveCam=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player")
        {
            MoveCam=false;
             Cameraa.GetComponent<CamFollow>().enabled=true;
        }
    }
}
