﻿using UnityEngine;
using System.Collections;

public class Loseta1_6 : Loseta {

	// Use this for initialization
	void Start () {
		numeroApariciones = 2;
		tiposEnLoseta = new tipoLoseta[] {tipoLoseta.CIUDAD_ESCUDO,tipoLoseta.CAMINO};
		ladosLoseta = new int[] { 0, 0, 1, 0, 0 };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
