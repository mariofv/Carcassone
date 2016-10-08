using UnityEngine;
using System.Collections;

public class BotonAceptar:Boton {
	public LosetaHightligth losetapadre;

	public void OnMouseUp() {

		losetapadre.Aceptar ();

	}

	public void SetPadre(LosetaHightligth losetapadre) {
		this.losetapadre = losetapadre;
	}
}