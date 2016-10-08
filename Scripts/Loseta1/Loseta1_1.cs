using UnityEngine;
using System.Collections;

public class Loseta1_1 : Loseta {
	
	// Use this for initialization
	void Start () {
		numeroApariciones = 2;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.MONASTERIO,tipoLoseta.CAMPO};
		ladosLoseta = new int[] { 2, 2, 0, 2, 1 };

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
