using UnityEngine;
using System.Collections;

public class Loseta2_2 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 5;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CIUDAD,tipoLoseta.CAMPO};
		ladosLoseta = new int[] {0,1,1,1,1};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
