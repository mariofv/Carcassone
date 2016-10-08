using UnityEngine;
using System.Collections;

public class Loseta4_5 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CAMPO};
		ladosLoseta = new int[] {1,0,1,0,1};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
