using UnityEngine;
using System.Collections;

public class Loseta2_4 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 2;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CIUDAD, tipoLoseta.CAMPO, tipoLoseta.CAMINO};
		ladosLoseta = new int[] {0,2,2,0,1};
		escudo = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
