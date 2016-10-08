using UnityEngine;
using System.Collections;

public class Loseta4_3 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CAMINO,tipoLoseta.CAMPO,tipoLoseta.CIUDAD};
		ladosLoseta = new int[] {3,0,0,1,2};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
