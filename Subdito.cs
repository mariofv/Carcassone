using UnityEngine;
using System.Collections;

public class Subdito : MonoBehaviour {
	
	public jugador jugador;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Debuelve el subdito a la mano y aumenta los puntos necesarios
	public void vuelveMano(int puntuacion){
		jugador.aumentaPuntos(putuacion);
	}
}
