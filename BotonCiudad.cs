using UnityEngine;
using System.Collections;

public class BotonCiudad : Boton {

	public LosetaHightligth parent;

	bool clicked = false;

	void OnMouseUp() {
		if (!clicked) {
			parent.SeleccionarCiudad ();
			clicked = true;
		}
	}
}
