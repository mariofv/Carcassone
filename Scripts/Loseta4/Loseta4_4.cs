using UnityEngine;
using System.Collections;

public class Loseta4_4 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 1;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CAMINO,tipoLoseta.CAMINO,tipoLoseta.CAMPO,tipoLoseta.CAMPO,tipoLoseta.MONASTERIO};
		ladosLoseta = new int[] {2,0,3,1,4};

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
