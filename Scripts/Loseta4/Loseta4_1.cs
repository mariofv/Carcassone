using UnityEngine;
using System.Collections;

public class Loseta4_1 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CAMPO};
		ladosLoseta = new int[] {0,0,1,1,0};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
