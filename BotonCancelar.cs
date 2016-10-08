using UnityEngine;
using System.Collections;

public class BotonCancelar:Boton {
	public LosetaHightligth losetaPadre;
	bool clicked = false;
	void  OnMouseUp() {
		if (!clicked) {
			clicked = true;
			losetaPadre.Cancelar ();
		}
	}

	public void SetLosetaPadre(LosetaHightligth loseta) {
		losetaPadre = loseta;
	}


}
