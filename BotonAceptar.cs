using UnityEngine;
using System.Collections;

public class BotonAceptar:Boton {
	public LosetaHightligth losetapadre;
	bool clicked = false;
	public void OnMouseUp() {
		if (!clicked) {
			clicked = true;
			losetapadre.Aceptar ();
		}

	}

	public void SetPadre(LosetaHightligth losetapadre) {
		this.losetapadre = losetapadre;
	}
}