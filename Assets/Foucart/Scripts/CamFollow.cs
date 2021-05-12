using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 100f;
    public Transform followTransform;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, this.transform.position.y, this.transform.position.z);
    }
    private void Update() {
         this.transform.position = new Vector3(followTransform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
