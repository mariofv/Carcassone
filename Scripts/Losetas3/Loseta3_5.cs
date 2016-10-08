using UnityEngine;
using System.Collections;

public class Loseta3_5 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CIUDAD,tipoLoseta.CAMPO};
		ladosLoseta = new int[] { 1,0,0,3,1 };

	}

	// Update is called once per frame
	void Update () {

	}
}
