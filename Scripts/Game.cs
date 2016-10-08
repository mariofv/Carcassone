using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	struct Coord {
		public int x, y;
	};

	Loseta[,] board = new Loseta[74, 74];

	Jugador[] jugadores = new Jugador[4];

	LinkedList<Coord> posiblesLosetas;

	Stack<GameObject> losetasAColocar;

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
		losetasAColocar = new Stack<GameObject> ();
		while (prueba.Count > 0) {
			int rand = Random.Range (0, prueba.Count);
			int selected = prueba [rand];
			prueba.Remove (selected);
		}
	}

	int possibleMovement(Loseta origen, Loseta adyacente) {
		return 0;
	}

	void place(GameObject loseta, int x, int y) {
	}

	int[] sumX = {0, 1, 0, -1};
	int[] sumY = { 1, 0, -1, 0 };

	void Update () {
		for (int i = 0; i < jugadores.Length; ++i) {
			Jugador jugador = jugadores [i];
			GameObject loseta = losetasAColocar.Pop ();
			foreach (Coord pos in posiblesLosetas) {
				int dir;
				if ((dir = possibleMovement (loseta.GetComponent<Loseta> (), board [pos.x, pos.y])) != -1) {
					place (loseta, pos.x + sumX[dir], pos.y + sumY[dir]);
				}
			}
		}
	}
}
