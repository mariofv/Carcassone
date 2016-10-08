using UnityEngine;
using System.Collections;

public class Loseta4_5 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CAMPO,tipoLoseta.CAMPO};
		ladosLoseta = new int[] {0,1,0,2,0};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
