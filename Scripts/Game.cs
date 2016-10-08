using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	Loseta[,] board = new Loseta[74, 74];

	Jugador[] jugadores = new Jugador[4];

	const int numF = 10;

	void Start () {
		for (int i = 0; i < 4; ++i) {
			Jugador jugador = gameObject.AddComponent<Jugador> ();
			jugador.puntos = 0;
			jugadores [i] = jugador;
		}
		List<int> prueba = new List<int>(numF);
		for (int i = 0; i < numF; ++i) {
			prueba.Add(i);
		}
		while (prueba.Count > 0) {
			int rand = Random.Range (0, prueba.Count);
			int selected = prueba [rand];
			prueba.Remove (selected);
		}
	}

	void Update () {
	
	}
}
