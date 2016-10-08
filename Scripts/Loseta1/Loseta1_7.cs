using UnityEngine;
using System.Collections;

public class Loseta1_7 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 4;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CIUDAD,tipoLoseta.CAMPO};
		ladosLoseta = new int[] { 0, 1, 0, 2, 0 };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
