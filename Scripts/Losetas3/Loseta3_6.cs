using UnityEngine;
using System.Collections;

public class Loseta3_6 :  Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 3;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CIUDAD,tipoLoseta.CAMINO,tipoLoseta.CAMINO,tipoLoseta.CAMINO};
		ladosLoseta = new int[] {1,0,2,3,1};

	}

	// Update is called once per frame
	void Update () {

	}
}
