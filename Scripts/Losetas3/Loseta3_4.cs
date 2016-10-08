using UnityEngine;
using System.Collections;

public class Loseta3_4 :  Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 3;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CIUDAD,tipoLoseta.CAMPO};
		ladosLoseta = new int[] { 0, 1, 3, 0, 0 };

	}

	// Update is called once per frame
	void Update () {

	}
}
