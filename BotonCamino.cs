using UnityEngine;
using System.Collections;

public class BotonCamino : Boton {

	public LosetaHightligth parent;
	bool clicked = false;
	void OnMouseUp() {
		if (!clicked) {
			clicked = true;
			parent.SeleccionarCamino ();
		}
	}
}
