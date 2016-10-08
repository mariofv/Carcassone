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

	const int numF = 34;

	void Start () {
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
		while (prueba.Count > 0) {
			int rand = Random.Range (0, prueba.Count);
			int selected = prueba [rand];
			GameObject loseta = Resources.Load<GameObject> ("Prefabs/Losetas/L" + selected);
			losetasAColocar.Push (loseta);
			prueba.RemoveAt (rand);
		}
		place (losetasAColocar.Pop (), 0, 0);
		place (losetasAColocar.Pop (), 0, 1);
		place (losetasAColocar.Pop (), 0, 2);
		place (losetasAColocar.Pop (), 0, 3);
		place (losetasAColocar.Pop (), 1, 3);
		place (losetasAColocar.Pop (), 1, 4);
		place (losetasAColocar.Pop (), 2, 0);
		place (losetasAColocar.Pop (), 0, 5);
		place (losetasAColocar.Pop (), 0, 6);
		place (losetasAColocar.Pop (), 1, 7);
		place (losetasAColocar.Pop (), 2, 0);
		place (losetasAColocar.Pop (), 3, 0);
	}

	int possibleMovement(Loseta origen, Loseta adyacente) {
		return 0;
	}

	void place(GameObject loseta, int x, int y) {
		Instantiate (loseta, new Vector3 (x * 4.52f + 2.26f, y*4.54f + 2.27f, 0), new Quaternion());
		//loseta.transform.position = new Vector2 (x * 2.26f, y * 2.27f);
	}

	int[] sumX = {0, 1, 0, -1};
	int[] sumY = { 1, 0, -1, 0 };

	/*void Update () {
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
	}*/
}
