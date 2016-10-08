using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	Loseta[,] board = new Loseta[72,72];

	Jugador[] jugadores = new Jugador[4];

	Stack<GameObject> losetasAPoner;

	const int numF = 10; 

	void Start() {
		for (int i = 0; i < jugadores.Length; ++i) {
			Jugador jugador = gameObject.AddComponent<Jugador> ();
			jugador.puntos = 0;
			jugadores [i] = jugador;
		}
		List<int> fichasAEscoger = new List<int>(numF);
		for (int i = 0; i < numF; ++i) {
			fichasAEscoger.Add (i);
		}
		while (fichasAEscoger.Count > 0) {
			string s = "";
			for (int i = 0; i < fichasAEscoger.Count; ++i) s += fichasAEscoger[i].ToString()+ " ";
			print (s);
			int rand = Random.Range (0, fichasAEscoger.Count);
			int fichaEscogida = fichasAEscoger [0];
			fichasAEscoger.Remove (0);
		}
	
	}

	void Update () {
	
	}
}
