using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    public int artefacts = 0;

	public Image[] artefactsImage;
	public Sprite artefactSprite;
	public Sprite emptyArtefactSprite;
	void Start()
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
            artefacts++;
			artefactsImage[artefacts-1].sprite = artefactSprite;
        }
    }
}
