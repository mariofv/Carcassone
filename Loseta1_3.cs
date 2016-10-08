using UnityEngine;
using System.Collections;

public class Loseta1_3 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CIUDAD,tipoLoseta.CAMPO,tipoLoseta.CAMPO};
		ladosLoseta = new int[] { 2, 0, 1, 0, 0 };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
