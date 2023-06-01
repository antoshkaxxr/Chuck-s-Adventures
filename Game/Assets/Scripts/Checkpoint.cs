using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Checkpoint : MonoBehaviour
{
    public Transform player;
    public int index;
    public TextMeshProUGUI checkpointText;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null && DataContainer.checkpointIndex == index)
        {
            player.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            DataContainer.checkpointIndex = index;
            checkpointText.enabled = false;
        }
    }
}
