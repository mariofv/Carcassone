using UnityEngine;
using System.Collections;

public class BotonGirar : MonoBehaviour {
	public Sprite spriteDefecto;
	public Sprite spritePulsado;
	// Use this for initialization
	void Start () {
	
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = spritePulsado;
	}

	void OnMouseExit() {
		print (gameObject.name);
		gameObject.GetComponent<SpriteRenderer> ().sprite = spriteDefecto;
	}

}
