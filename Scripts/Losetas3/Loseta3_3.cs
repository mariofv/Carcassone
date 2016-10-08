using UnityEngine;
using System.Collections;

public class Loseta3_3 :  Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 3;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMPO,tipoLoseta.CIUDAD,tipoLoseta.CIUDAD};
		ladosLoseta = new int[] { 0, 1,0, 2, 0 };

	}

	// Update is called once per frame
	void Update () {

	}
}
