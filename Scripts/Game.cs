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
	public static bool losetaEscogida;
	const int numF = 34;
	const int numFT = 84;
	const int sizeX = numFT * 2;
	const int sizeY = numFT * 2;

	Loseta[,] board = new Loseta[sizeX, sizeY];

	public static Jugador[] jugadores = new Jugador[4];

	bool primeraRonda = true;

	Stack<GameObject> losetasAColocar;

	GameObject ultimaLoseta;

	direcciones[] dirs = { direcciones.ARRIBA, direcciones.DERECHA, direcciones.ABAJO, direcciones.IZQUIERDA };
	int[] sumX = {0, 1, 0, -1};
	int[] sumY = { 1, 0, -1, 0 };

	private IEnumerator coroutine;

	public static void iniJugadores() {
		for (int i = 0; i < 4; ++i) {
			Jugador jugador = new Jugador();
			jugador.puntos = 0;
			jugador.subditos = 8;
			jugadores [i] = jugador;
		}
	}

	void Start () {
		Camera.main.transform.position = new Vector3 (numFT * 4.52f + 2.26f, numFT * 4.54f + 2.27f, GlobalVariables.cameraZ);
		if (jugadores [0] == null) {
			for (int i = 0; i < 4; ++i) {
				Jugador jugador = new Jugador ();
				jugador.puntos = 0;
				jugador.subditos = 8;
				jugadores [i] = jugador;
			}
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
		
	public static void place(GameObject loseta, int x, int y) {
		loseta.transform.position =  new Vector3 (x * 4.52f + 2.26f, y*4.54f + 2.27f, 0);
	}

	bool[,] visitado = new bool[sizeX, sizeY];
	int[] subditosJugador = new int[4];
	int puntuacion;
	int profMax;

	bool analisis(Coord coord, tipoLoseta tipo, direcciones dirAnterior, int profundidad) {
		Loseta loseta = board [coord.x, coord.y];
		if (loseta == null) return false;
		profMax = (profMax < profundidad ? profundidad : profMax);
		int lado = loseta.ladosLoseta [Utils.opuesto((int)dirAnterior)];
		tipoLoseta[] tipos = loseta.tiposEnLoseta;
		foreach (direcciones dir in dirs) {
			Coord next = new Coord(coord.x + sumX[(int)dir], coord.y + sumY[(int)dir]);
				if (!visitado[next.x, next.y] &&
				tipos[loseta.ladosLoseta[(int)dir]] == tipo && 
				loseta.ladosLoseta[(int)dir] != lado) {
				if (!analisis(next, tipo, dir, profundidad+1)) return false;
				}
		}
		if (loseta.tipoSubdito == tipo) {
			++subditosJugador [loseta.subdito.jugador.indice];
		}
		if (tipo == tipoLoseta.CAMINO) ++puntuacion;
		else {
			puntuacion += 2;
			if (loseta.escudo) ++puntuacion;
		}
		return true;
	}

	public static int selectedX, selectedY;
	public static int rot;
	public static tipoLoseta tipoSeleccionado;

	IEnumerator gameLoop() {
		while (losetasAColocar.Count > 0) {
			for (int i = 0; i < jugadores.Length; ++i) {
				Jugador jugador = jugadores [i];
				GameObject loseta = losetasAColocar.Pop ();
				loseta = (GameObject)Instantiate (loseta, new Vector3 (0, 0, -100), Quaternion.identity);
				yield return null;
				Loseta losetaClass = loseta.GetComponent<Loseta> ();
				UIController.SetActualTile(loseta.gameObject.GetComponent<SpriteRenderer> ().sprite);
				if (primeraRonda) {
					primeraRonda = false;
					GameObject highlight = Resources.Load<GameObject> ("Prefabs/LosetaHighlitgh");
					GameObject instance = Instantiate (highlight);
					LosetaHightligth losetaHighlight = instance.GetComponent<LosetaHightligth> ();
					losetaHighlight.loseta = losetaClass;
					losetaHighlight.x = numFT;
					losetaHighlight.y = numFT;
					losetaHighlight.validRot = new bool[4];
					for (int j = 0; j < 4; ++j)
						losetaHighlight.validRot [j] = true;	
					place (instance, numFT, numFT);
				} else {
					for (int j = 0; j < sizeX; ++j) {
						for (int k = 0; k < sizeY; ++k) {
							bool[] rotValidas = posicionPosible (loseta.GetComponent<Loseta> (), new Coord (j, k));
							int l = 0;
							while (l < 4 && !rotValidas [l])
								++l; 
							if (l < 4) {
								GameObject highlight = Resources.Load<GameObject> ("Prefabs/LosetaHighlitgh");
								GameObject instance = Instantiate (highlight);
								LosetaHightligth losetaHighlight = instance.GetComponent<LosetaHightligth> ();
								losetaHighlight.validRot = rotValidas;
								losetaHighlight.loseta = losetaClass;
								losetaHighlight.x = j;
								losetaHighlight.y = k;
								place (instance, j, k);
							}
						}
					}
				}
				losetaEscogida = false;
				while (!losetaEscogida) {
					yield return null;
				}

				Coord selected = new Coord (selectedX, selectedY);
				board [selected.x, selected.y] = loseta.GetComponent<Loseta> ();
				if (tipoSeleccionado == tipoLoseta.NADA) {
					print ("nada");
				} else if (tipoSeleccionado == tipoLoseta.CATEDRAL) {
					int count = 0;
					for (int j = selected.x - 1; j < selected.x + 1; ++j) {
						for (int k = selected.y - 1; k < selected.y + 1; ++k) {
							if (j != selected.x && k != selected.y) {
								if (board [j, k] != null)
									++count;
							}
						}
					}
					if (count == 8)
						jugador.puntos += 9;
				} else {
					Loseta losetaSelected = board [selected.x, selected.y];
					bool[] visited = new bool[losetaSelected.tiposEnLoseta.Length];
					for (int j = 0; j < visited.Length; ++i)
						visited [j] = false;
					foreach (direcciones dir in dirs) {
						if (losetaSelected.tiposEnLoseta [losetaSelected.ladosLoseta [(int)dir]] == tipoSeleccionado &&
						    !visited [losetaSelected.ladosLoseta [(int)dir]]) {
							visited [losetaSelected.ladosLoseta [(int)dir]] = true;
							for (int j = 0; j < sizeX; ++j)
								for (int k = 0; k < sizeY; ++k)
									visitado [j, k] = false;
							for (int j = 0; j < subditosJugador.Length; ++j)
								subditosJugador [j] = 0;
							if (analisis (new Coord (selected.x + sumX [(int)dir], selected.y + sumY [(int)dir]), tipoSeleccionado, dir, 0)) {
								int max = -1;
								LinkedList<int> maximos = null;
								for (int j = 0; j < 4; ++j) {
									if (subditosJugador [j] > subditosJugador [max]) {
										max = j;
										maximos = new LinkedList<int> ();
										maximos.AddLast (max);
									} else if (subditosJugador [j] == subditosJugador [max]) {
										maximos.AddLast (max);
									}
								}
								if (tipoSeleccionado == tipoLoseta.CIUDAD && profMax == 0)
									puntuacion = 2;
								foreach (int player in maximos) {
									jugadores [player].puntos += puntuacion;
								}
							}
						}
					}
				}
			}
		}
		//TODO: terminar juego
	}
}
