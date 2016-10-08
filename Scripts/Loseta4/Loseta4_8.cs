using UnityEngine;
using System.Collections;

public class Loseta4_8 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 1;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CAMPO,tipoLoseta.CIUDAD};
		ladosLoseta = new int[] {1,2,2,0,0};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
