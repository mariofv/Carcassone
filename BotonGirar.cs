using UnityEngine;
using System.Collections;

public class BotonGirar : Boton {
	public Loseta losetaLigada;

	void OnMouseUp() {
		losetaLigada.rotar (-90);
	}
}
