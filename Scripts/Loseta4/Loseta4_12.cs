using UnityEngine;
using System.Collections;

public class Loseta4_12 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 1;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMPO,tipoLoseta.CIUDAD,tipoLoseta.CIUDAD,tipoLoseta.CIUDAD};
		ladosLoseta = new int[] {1,2,0,3,0};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
