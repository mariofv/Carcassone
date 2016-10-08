using UnityEngine;
using System.Collections;

public class Loseta1_9 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMPO,tipoLoseta.CAMINO,tipoLoseta.CAMINO,tipoLoseta.CAMINO};
		ladosLoseta = new int[] { 0, 1, 2, 3, 0 };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
