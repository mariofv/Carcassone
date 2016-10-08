using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	/*
	struct Coord {
		public int x, y;
	};
*/
	const int numF = 34;
	const int numFT = 84;

	Loseta[,] board = new Loseta[2*numFT, 2*numFT];

	Jugador[] jugadores = new Jugador[4];

	//LinkedList<Coord> posiblesLosetas;

	Stack<GameObject> losetasAColocar;

	GameObject ultimaLoseta;



	void Start () {
		Camera.main.transform.position = new Vector3 (numFT * 4.52f + 2.26f, numFT * 4.54f + 2.27f, -60);
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
		int[] aparicionesRestantes = new int[numF];
		for (int i = 0; i < numF; ++i) aparicionesRestantes[i] = -1;
		while (prueba.Count > 0) {
			int rand = Random.Range (0, prueba.Count);
			int selected = prueba [rand];
			GameObject loseta = Resources.Load<GameObject> ("Prefabs/Losetas/L" + selected);
			losetasAColocar.Push (loseta);
			if (aparicionesRestantes[selected] == -1) {
				Loseta los = loseta.GetComponent<Loseta> ();
				aparicionesRestantes[selected] = los.numeroApariciones;
			}
			if (--aparicionesRestantes [selected] == 0) prueba.RemoveAt (rand);
			if (aparicionesRestantes [selected] < 0) {
				print ("Algoritmo fallido");
				Debug.Break ();
			}
		}
		print (losetasAColocar.Count);
		ultimaLoseta = Instantiate (losetasAColocar.Pop());
		place (ultimaLoseta, numFT, numFT);
	}


	int possibleMovement(Loseta origen, Loseta adyacente) {
		return 0;
	}

	void pruebaRotar(Loseta loseta) {
		direcciones[] dir = { direcciones.ARRIBA, direcciones.DERECHA, direcciones.ABAJO, direcciones.IZQUIERDA };
		foreach (direcciones d in dir) {
			foreach (direcciones d2 in dir) {
				print("Holaa amijo estoy rotando desde " + d + " hasta a " + d2);
				loseta.rotaFicha((int)d,(int)d2);
				loseta.rotaFicha((int)d2,(int)d);

			}
		}
	
	}


	void place(GameObject loseta, int x, int y) {
		loseta.transform.position =  new Vector3 (x * 4.52f + 2.26f, y*4.54f + 2.27f, 0);
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
		

	void Update () {
	}
}
