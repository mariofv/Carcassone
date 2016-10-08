using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	struct Coord {
		public int x, y;
	};
	bool losetaEscogida;
	const int numF = 34;
	const int numFT = 84;

	Loseta[,] board = new Loseta[2*numFT, 2*numFT];

	Jugador[] jugadores = new Jugador[4];

	LinkedList<Coord> posiblesLosetas;

	Stack<GameObject> losetasAColocar;

	GameObject ultimaLoseta;

	direcciones[] dirs = { direcciones.ARRIBA, direcciones.DERECHA, direcciones.ABAJO, direcciones.IZQUIERDA };
	int[] sumX = {0, 1, 0, -1};
	int[] sumY = { 1, 0, -1, 0 };

	void Start () {
		Camera.main.transform.position = new Vector3 (numFT * 4.52f + 2.26f, numFT * 4.54f + 2.27f, GlobalVariables.cameraZ);
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
		ultimaLoseta = Instantiate (losetasAColocar.Pop());
		place (ultimaLoseta, numFT, numFT);
		StartCoroutine ("gameLoop");
	}


	LinkedList<int>[] possibleMovement(Loseta origen, Loseta adyacente, Coord cDest) {
		tipoLoseta[] tiposDest = adyacente.tiposEnLoseta;
		tipoLoseta[] tiposOr = origen.tiposEnLoseta;
		LinkedList<int>[] possiblePairs = new LinkedList<int>[dirs.Length];
		foreach (direcciones dDest in dirs) {
			if (board [cDest.x + sumX [(int)dDest], cDest.y + sumY [(int)dDest]] == null) {
				tipoLoseta tipoDest = tiposDest [adyacente.ladosLoseta [(int)dDest]];
				foreach (direcciones dOr in dirs) {
					tipoLoseta tipoOr = tiposOr [origen.ladosLoseta [(int)dOr]];
					if (tipoDest == tipoOr) {
						possiblePairs[(int)dDest].AddLast ((int)dOr);
					}
				}
			}
		}
		return possiblePairs;
	}

	void pruebaRotar(Loseta loseta) {
		foreach (direcciones d in dirs) {
			foreach (direcciones d2 in dirs) {
				print("Holaa amijo estoy rotando desde " + d + " hasta a " + d2);
				loseta.rotaFicha((int)d,(int)d2);
				loseta.rotaFicha((int)d2,(int)d);

			}
		}
	
	}
		
	void place(GameObject loseta, int x, int y) {
		loseta.transform.position =  new Vector3 (x * 4.52f + 2.26f, y*4.54f + 2.27f, 0);
	}

	void gameLoop() {
		for (int i = 0; i < jugadores.Length; ++i) {
			Jugador jugador = jugadores [i];
			GameObject loseta = (GameObject)Instantiate (losetasAColocar.Pop (), Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth*0.5f, Camera.main.pixelHeight*(1f/10f), GlobalVariables.cameraZ)), Quaternion.identity);
			if (posiblesLosetas == null) {
				posiblesLosetas = new LinkedList<Coord> ();
				Coord ini = new Coord ();
				ini.x = ini.y = numFT;
				posiblesLosetas.AddLast (ini);
			}
			LinkedListNode<Coord> it = posiblesLosetas.First;
			while (it != posiblesLosetas.Last) {
				LinkedList<int>[]dir = possibleMovement (loseta.GetComponent<Loseta> (), board [it.Value.x, it.Value.y], it.Value);
				//TODO: Instanciar highlight en coordenadas determinadas por dirs
				losetaEscogida = false;
				while (!losetaEscogida);
				bool surrounded = true;
				for (int j = 0; j < dirs.Length; ++j) {
					if (board [it.Value.x + sumX [j], it.Value.y + sumY [j]] == null) surrounded = false;
				}
				if (surrounded) {
					LinkedListNode<Coord> nodeAEliminar = it;
					it = it.Next;
					posiblesLosetas.Remove (nodeAEliminar);
				}
			}
		}
	}
		

	void Update () {
	}
}
