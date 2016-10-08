using UnityEngine;
using System.Collections;

public class Loseta1_5 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 2;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CIUDAD,tipoLoseta.CIUDAD,tipoLoseta.CAMPO};
		ladosLoseta = new int[] { 2, 0, 1, 2, 2 };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
