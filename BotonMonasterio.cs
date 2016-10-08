using UnityEngine;
using System.Collections;

public class BotonMonasterio : Boton {

	public LosetaHightligth parent;
	bool clicked = false;
	void OnMouseUp() {
		if (!clicked) {
			clicked = true;
			parent.SeleccionarMonasterio ();
		}
	}
}
