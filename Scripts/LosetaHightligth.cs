using UnityEngine;
using System.Collections;

public class LosetaHightligth : MonoBehaviour {

	public bool[] validRot;
	public GameObject aceptar;
	public GameObject cancelar;
	public GameObject rotar;
	int x = 0, y = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	} 

	public void Aceptar() {
		Game.selectedX = x;
		Game.selectedY = y;
		Game.losetaEscogida = true;
	}

	public void Cancelar() {
		//DESTRUIR HIJOS
	}

	public void OnMouseUp() {
		// rot1, rot2 que es la rotación para poner poner en loseta.rota, tipoSeleccionado que es donde el jugador pone el subdito.


		ligaBotones ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = UIController.actualTile.sprite;
		Camera.main.GetComponent<MoveCamera>().centerCamera (gameObject);

	}

	private void ligaBotones() {
		aceptar = (GameObject)Instantiate (aceptar.gameObject, new Vector3 (transform.position.x - 2, transform.position.y - 3.5f, 0), Quaternion.identity);
		aceptar.GetComponent<BotonAceptar> ().SetPadre (this);

		cancelar = (GameObject)Instantiate (cancelar.gameObject, new Vector3 (transform.position.x - 0, transform.position.y - 3.5f, 0), Quaternion.identity);
		rotar = (GameObject)Instantiate (rotar.gameObject, new Vector3 (transform.position.x + 2, transform.position.y - 3.5f, 0), Quaternion.identity);

	}
}
