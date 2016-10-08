using UnityEngine;
using System.Collections;

public class BotonNada : Boton {

	public LosetaHightligth parent;
	bool clicked = false;
	void OnMouseUp() {
		if (!clicked) {
			clicked = true;
			parent.SeleccionarNada ();
		}
	}
}
