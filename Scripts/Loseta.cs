using UnityEngine;
using System.Collections;

public class Loseta : MonoBehaviour {

	//Estos vectores tiene los tipos de cada lado de la ficha
	public int[] ladosLoseta;
	public tipoLoseta[] tiposEnLoseta;
	//Donde esta situado el subdito, -1 indica sin subdito.
	public tipoLoseta tipoSubdito;
	//El subdito :D
	Subdito subdito;

	// Use this for initialization
	void Start () {
		ladosLoseta = new int[5];
		tipoSubdito = -1;
	}
	

}
