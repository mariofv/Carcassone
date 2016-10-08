using UnityEngine;
using System.Collections;

public class LosetaHightligth : MonoBehaviour {

	public bool[] validRot;
	public GameObject aceptar;
	public GameObject cancelar;
	public GameObject rotar;
	int x, y;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	} 

	public void OnMouseUp() {
		ligaBotones ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = UIController.actualTile.sprite;
		Camera.main.GetComponent<MoveCamera>().centerCamera (gameObject);
	}

	private void ligaBotones() {
		aceptar = (GameObject)Instantiate (aceptar.gameObject, new Vector3 (transform.position.x - 2, transform.position.y - 3.5f, 0), Quaternion.identity);
		cancelar = (GameObject)Instantiate (cancelar.gameObject, new Vector3 (transform.position.x - 0, transform.position.y - 3.5f, 0), Quaternion.identity);
		rotar = (GameObject)Instantiate (rotar.gameObject, new Vector3 (transform.position.x + 2, transform.position.y - 3.5f, 0), Quaternion.identity);

	}
}
