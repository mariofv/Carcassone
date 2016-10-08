using UnityEngine;
using System.Collections;

public class Loseta3_10 :  Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 9;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMPO,tipoLoseta.CIUDAD};
		ladosLoseta = new int[] {1,1,0,1,1};

	}

	// Update is called once per frame
	void Update () {

	}
}
