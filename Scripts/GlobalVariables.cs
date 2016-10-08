using UnityEngine;
using System.Collections;

public enum tipoLoseta { CAMPO, RIO, CAMINO, CIUDAD, CATEDRAL, MONASTERIO, NADA, CIUDAD_ESCUDO};

public enum direcciones {ARRIBA,DERECHA,ABAJO,IZQUIERDA};


public class GlobalVariables : MonoBehaviour {
	public static int cameraZ {
		get {
			return pcameraZ;
		}
	}
	private static int pcameraZ = -50;
}
