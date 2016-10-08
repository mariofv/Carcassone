using UnityEngine;
using System.Collections;

public class Loseta3_10 :  Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 8;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMPO,tipoLoseta.CAMINO};
		ladosLoseta = new int[] {0,1,1,0,0};

	}

	// Update is called once per frame
	void Update () {

	}
}
