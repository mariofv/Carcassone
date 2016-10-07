using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	Loseta[,] board = new Loseta[72,72];

	Jugador[] jugadores = new Jugador[4];

	Stack<GameObject> losetasAPoner; 

	void Start() {
		for (int i = 0; i < jugadores.Length; ++i) {
			Jugador jugador = gameObject.AddComponent<Jugador> ();
			jugador.puntos = 0;
			jugadores [i] = jugador;
		}
		GameObject hola = Resources.Load<GameObject> ("Prefabs");
		if (hola != null)
			print (hola);
		else
			print ("fail");
	}

	void Update () {
	
	}
}
