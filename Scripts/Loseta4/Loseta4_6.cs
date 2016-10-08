using UnityEngine;
using System.Collections;

public class Loseta4_6 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 9;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CAMPO};
		ladosLoseta = new int[] {1,0,0,1,0};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
