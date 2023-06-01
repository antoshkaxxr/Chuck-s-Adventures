using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
	public int artefacts = 0;
	[SerializeField] private AudioSource collectArtefact;
	public Image[] artefactsImage;
	public Sprite artefactSprite;
	public Sprite emptyArtefactSprite;
	public TextMeshProUGUI artefactsText;

	public void Start()
    {
        for (int i = 0; i < artefactsImage.Length; i++)
   		{
        	artefactsImage[i].sprite = emptyArtefactSprite;
    	}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Artefact"))
        {
            Destroy(collision.gameObject);
			collectArtefact.Play();
            artefacts++;
			artefactsImage[artefacts-1].sprite = artefactSprite;
			artefactsText.enabled = false;
        }
    }
}
