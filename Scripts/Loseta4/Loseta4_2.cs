using UnityEngine;
using System.Collections;

public class Loseta4_2 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CAMPO,tipoLoseta.CIUDAD};
		ladosLoseta = new int[] {2,0,1,1,0};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
