using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	LosetaAtributos[,] board = new LosetaAtributos[72,72];

	Jugador[] jugadores = new Jugador[4];

	Stack<GameObject> losetasAPoner; 

	void Start() {
		for (int i = 0; i < jugadores.Length; ++i) {
			Jugador jugador = new Jugador();
			jugador.puntos = 0;
			jugadores [i] = jugador;
		}

	}

	void Update () {
	
	}
}
