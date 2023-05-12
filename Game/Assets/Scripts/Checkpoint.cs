using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform player;
    public int index;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (DataContainer.checkpointIndex == index)
            player.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            DataContainer.checkpointIndex = index;
    }
}
