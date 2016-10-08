using UnityEngine;
using System.Collections;

public class LosetaHightligth : MonoBehaviour {

	public bool[] validRot;
	public GameObject aceptar;
	public GameObject cancelar;
	public GameObject rotar;
	public GameObject ciudad;
	public GameObject camino;
	public GameObject monasterio;
	public GameObject nada;

	public GameObject aceptarI;
	public GameObject cancelarI;
	public GameObject rotarI;
	public GameObject ciudadI;
	public GameObject caminoI;
	public GameObject monasterioI;
	public GameObject nadaI;

	public int x = 0, y = 0;
	public Loseta loseta;

	struct Pair {
		public int first, second;
		public Pair(int first, int second) {
			this.first = first;
			this.second = second;
		}
	};

	public void Aceptar() {
		Game.selectedX = x;
		Game.selectedY = y;
		bool[] visitado = new bool[10];
		for (int i = 0; i < 10; ++i) visitado [i] = false;
		foreach (tipoLoseta tipo in loseta.tiposEnLoseta) {
			if (tipo == tipoLoseta.CIUDAD && !visitado [(int)tipo]) {
				visitado [(int)tipo] = true;
				ciudadI = (GameObject)Instantiate (ciudad, new Vector3 (transform.position.x + 5f, transform.position.y - 3f, 0), Quaternion.identity);
				ciudadI.GetComponent<BotonCiudad> ().parent = this;
			} 
			else if (tipo == tipoLoseta.CAMINO && !visitado [(int)tipo]) {
				visitado [(int)tipo] = true;
				caminoI = (GameObject)Instantiate (camino, new Vector3 (transform.position.x + 5f, transform.position.y - 1.5f, 0), Quaternion.identity);
				caminoI.GetComponent<BotonCamino> ().parent = this;
			} 
			else if (tipo == tipoLoseta.MONASTERIO && !visitado [(int)tipo]) {
				visitado [(int)tipo] = true;
				monasterioI = (GameObject)Instantiate (monasterio, new Vector3 (transform.position.x + 5f, transform.position.y - 1f, 0), Quaternion.identity);
				monasterioI.GetComponent<BotonMonasterio> ().parent = this;
			}
		}
		nadaI = (GameObject)Instantiate (nada, new Vector3 (transform.position.x + 5f, transform.position.y + 0.5f, 0), Quaternion.identity);
		nadaI.GetComponent<BotonNada> ().parent = this;
	}

	public void SeleccionarCiudad() {
		Game.tipoSeleccionado = tipoLoseta.CIUDAD;
		destroyAll ();
		Game.losetaEscogida = true;
		Destroy (gameObject);
	}

	public void SeleccionarCamino() {
		Game.tipoSeleccionado = tipoLoseta.CAMINO;
		destroyAll ();
		Game.losetaEscogida = true;
		Destroy (gameObject);
	}

	public void SeleccionarMonasterio() {
		Game.tipoSeleccionado = tipoLoseta.MONASTERIO;
		destroyAll ();
		Game.losetaEscogida = true;
		Destroy (gameObject);
	}

	public void SeleccionarNada() {
		Game.tipoSeleccionado = tipoLoseta.NADA;
		destroyAll ();
		Game.losetaEscogida = true;
		Destroy (gameObject);
	}

	void destroyAll() {
		Destroy(aceptarI);
		Destroy(cancelarI);
		Destroy(rotarI);
		Destroy(ciudadI);
		Destroy(caminoI);
		Destroy(monasterioI);
		Destroy(nadaI);
	}

	public void Cancelar() {
		loseta.transform.position = new Vector3 (0, 0, -100);
		destroyAll ();
		clicked = false;
	}
	bool clicked = false;
	public void OnMouseUp() {
		if (!clicked) {
			clicked = true;
			ligaBotones ();
			Game.place (loseta.gameObject, x, y);
			Camera.main.GetComponent<MoveCamera> ().centerCamera (gameObject);
		}

	}

	private void ligaBotones() {
		aceptarI = (GameObject)Instantiate (aceptar, new Vector3 (transform.position.x - 2, transform.position.y - 3.5f, 0), Quaternion.identity);
		aceptarI.GetComponent<BotonAceptar> ().SetPadre (this);

		cancelarI = (GameObject)Instantiate (cancelar, new Vector3 (transform.position.x - 0, transform.position.y - 3.5f, 0), Quaternion.identity);
		cancelarI.GetComponent<BotonCancelar> ().SetLosetaPadre (this);
		rotarI = (GameObject)Instantiate (rotar, new Vector3 (transform.position.x + 2, transform.position.y - 3.5f, 0), Quaternion.identity);
		rotarI.GetComponent<BotonGirar> ().losetaLigada = loseta;
	}
}
