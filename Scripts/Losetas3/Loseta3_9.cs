using UnityEngine;
using System.Collections;

public class Loseta3_9 :  Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 3;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMPO,tipoLoseta.CAMINO};
		ladosLoseta = new int[] {0,0,1,1,1};

	}

	// Update is called once per frame
	void Update () {

	}
}
