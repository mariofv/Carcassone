using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameM : MonoBehaviour {

	struct Coord {
		public int x, y;
	};

	const int numF = 34;

	Loseta[,] board = new Loseta[2*numF, 2*numF];

	Jugador[] jugadores = new Jugador[4];

	LinkedList<Coord> posiblesLosetas;

	Stack<GameObject> losetasAColocar;



	void Start () {
		Camera.main.transform.position = new Vector3 (numF * 4.52f + 2.26f, numF * 4.54f + 2.27f, -60);
		for (int i = 0; i < 4; ++i) {
			Jugador jugador = gameObject.AddComponent<Jugador> ();
			jugador.puntos = 0;
			jugador.subditos = 8;
			jugadores [i] = jugador;
		}
		List<int> prueba = new List<int>(numF);
		for (int i = 0; i < numF; ++i) {
			prueba.Add(i);
		}
		losetasAColocar = new Stack<GameObject> ();
		//int[] aparicionesRestantes = new int[numF];
		//for (int i = 0; i < numF; ++i) aparicionesRestantes[i] = -1;
		while (prueba.Count > 0) {
			int rand = Random.Range (0, prueba.Count);
			int selected = prueba [rand];
			GameObject loseta = Resources.Load<GameObject> ("Prefabs/Losetas/L" + selected);
			losetasAColocar.Push (loseta);
			/*if (aparicionesRestantes[selected] == -1) {
				Loseta los = loseta.GetComponent<Loseta> ();
				aparicionesRestantes[selected] = los.numeroApariciones;
			}
			if (--aparicionesRestantes[selected] == 0)*/ prueba.RemoveAt (rand);
		}
		print (losetasAColocar.Count);
		place (losetasAColocar.Pop (), numF, numF);
	}

	int possibleMovement(Loseta origen, Loseta adyacente) {
		return 0;
	}

	void place(GameObject loseta, int x, int y) {
		Instantiate (loseta, new Vector3 (x * 4.52f + 2.26f, y*4.54f + 2.27f, 0), new Quaternion());
	}

	int[] sumX = {0, 1, 0, -1};
	int[] sumY = { 1, 0, -1, 0 };

	void gameLoop() {
		/*for (int i = 0; i < jugadores.Length; ++i) {
			Jugador jugador = jugadores [i];
			GameObject loseta = losetasAColocar.Pop ();
			foreach (Coord pos in posiblesLosetas) {
				int dir;
				if ((dir = possibleMovement (loseta.GetComponent<Loseta> (), board [pos.x, pos.y])) != -1) {
					place (loseta, pos.x + sumX[dir], pos.y + sumY[dir]);
				}
			}
		}*/
	}

	/*void Update () {
	}*/
}
