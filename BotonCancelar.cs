using UnityEngine;
using System.Collections;

public class BotonCancelar:Boton {
	public LosetaHightligth losetaPadre;
	// Use this for initialization
	void  OnMouseUp() {

		losetaPadre.Cancelar ();

	}

	public void SetLosetaPadre(LosetaHightligth loseta) {
		losetaPadre = loseta;
	}


}
