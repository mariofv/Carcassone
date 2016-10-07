using UnityEngine;
using System.Collections;

public class Loseta1_2 : Loseta {

	// Use this for initialization
	void Start () {
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.MONASTERIO,tipoLoseta.CAMPO};
		ladosLoseta = new int[] { 1, 1, 1, 1, 0 };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
