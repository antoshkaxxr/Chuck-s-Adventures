using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int artefacts = 0;

    [SerializeField] private Text artefactText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Artefact"))
        {
            Destroy(collision.gameObject);
            artefacts++;
            artefactText.text = "Реликвии: " + artefacts + "/6";
        }
    }
}
