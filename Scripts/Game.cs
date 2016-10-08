using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	struct Coord {
		public int x, y;
		public Coord(int x, int y) {
			this.x = x;
			this.y = y;
		}
	};
	bool losetaEscogida;
	const int numF = 34;
	const int numFT = 84;
	const int sizeX = numFT * 2;
	const int sizeY = numFT * 2;

	Loseta[,] board = new Loseta[sizeX, sizeY];

	Jugador[] jugadores = new Jugador[4];

	bool primeraRonda = true;

	Stack<GameObject> losetasAColocar;

	GameObject ultimaLoseta;

	direcciones[] dirs = { direcciones.ARRIBA, direcciones.DERECHA, direcciones.ABAJO, direcciones.IZQUIERDA };
	int[] sumX = {0, 1, 0, -1};
	int[] sumY = { 1, 0, -1, 0 };

	private IEnumerator coroutine;

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
		coroutine = gameLoop ();
		StartCoroutine (coroutine);
	}

	bool[] posicionPosible(Loseta losetaAColocar, Coord coord) {
		tipoLoseta[] tiposLoseta = losetaAColocar.tiposEnLoseta;
		bool[] rot = new bool[4];
		for (int i = 0; i < 4; ++i) {
			rot[i] = false;
			losetaAColocar.rotaFicha (0, i);
			foreach (direcciones dir in dirs) {
				tipoLoseta tipoLoseta = tiposLoseta [losetaAColocar.ladosLoseta [(int)dir]];
				Coord adyacente = new Coord ();
				adyacente.x = coord.x + sumX [(int)dir];
				adyacente.y = coord.y + sumY [(int)dir];
				if (adyacente.x >= 0 && adyacente.x < sizeX && adyacente.y >= 0 && adyacente.y < sizeY) {
					Loseta loseta = board [adyacente.x, adyacente.y];
					if (loseta != null) {
						tipoLoseta tipoAdyacente = loseta.tiposEnLoseta[loseta.ladosLoseta [Utils.opuesto ((int)dir)]];
						if (tipoAdyacente == tipoLoseta) {
							rot[i] = true;
						}
					}
				}
			}
		}
		return rot;
	}
		
	void place(GameObject loseta, int x, int y) {
		loseta.transform.position =  new Vector3 (x * 4.52f + 2.26f, y*4.54f + 2.27f, 0);
	}

	IEnumerator gameLoop() {
		for (int i = 0; i < jugadores.Length; ++i) {
			Jugador jugador = jugadores [i];
			GameObject loseta = (GameObject)Instantiate (losetasAColocar.Pop (), Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth*0.5f, Camera.main.pixelHeight*(1f/10f), -GlobalVariables.cameraZ)), Quaternion.identity);
			if (primeraRonda) {
				primeraRonda = false;
				GameObject highlight = Resources.Load<GameObject> ("Prefabs/LosetaHighlitgh");
				LosetaHightligth losetaHighlight = highlight.GetComponent<LosetaHightligth> ();
				losetaHighlight.validRot = new bool[4];
				for (int j = 0; j < 4; ++j) losetaHighlight.validRot[j] = true;	
				GameObject instance = Instantiate (highlight);
				place (instance, numFT, numFT);
			} 
			else {
				for (int j = 0; j < sizeX; ++j) {
					for (int k = 0; k < sizeY; ++k) {
						bool[] rotValidas = posicionPosible (loseta.GetComponent<Loseta> (), new Coord (j, k));
						int l = 0;
						while (l < 4 && !rotValidas [l]) ++l; 
						if (l < 4) {
							GameObject highlight = Resources.Load<GameObject> ("Prefabs/LosetaHighlitgh");
							LosetaHightligth losetaHighlight = highlight.GetComponent<LosetaHightligth> ();
							losetaHighlight.validRot = rotValidas;
							GameObject instance = Instantiate (highlight);
							place (instance, j, k);
						}
					}
				}
			}
			losetaEscogida = false;
			while (!losetaEscogida) {
				yield return true;
			}
		}
	}
		

	void Update () {
	}
}
