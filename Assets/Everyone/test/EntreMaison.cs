﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreMaison : MonoBehaviour
{
    public Vector3 EntreMaisonPos;
    public GameObject Player;
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
            Player.transform.position=EntreMaisonPos;
        }
    }
}