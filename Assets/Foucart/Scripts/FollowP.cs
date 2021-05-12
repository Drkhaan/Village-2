using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowP : MonoBehaviour
{
    public bool Follow;
    public Transform Play;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Follow==true)
        {
            this.transform.position=new Vector3(Play.position.x,Play.position.y,this.transform.position.z);
        }
    }
}
