using UnityEngine;
using System.Collections;

public class Loseta : MonoBehaviour {

	public int numeroApariciones;
	//Estos vectores tiene los tipos de cada lado de la ficha
	public int[] ladosLoseta;
	public tipoLoseta[] tiposEnLoseta;
	//Donde esta situado el subdito, -1 indica sin subdito.
	public tipoLoseta tipoSubdito;
	//El subdito :D
	public Subdito subdito;
	//Boton Rotar
	BotonGirar botonRotar;
	public bool escudo;

	// Use this for initialization
	void Start () {
		ladosLoseta = new int[5];
		tipoSubdito = tipoLoseta.NADA;
		escudo = false;
	}
		
	public void ligaBotonRotar() {
		botonRotar = new BotonGirar();
		botonRotar.transform.parent = gameObject.transform;
		botonRotar.losetaLigada = gameObject.GetComponent<Loseta>();
	
	}

	public void rotaFicha(int direccionObservada, int direccionDeseada) {
		int grau = Utils.grau (direccionObservada, direccionDeseada);
		gameObject.transform.Rotate (0, 0, grau);
		int factor = (grau / 90);
		int[] ladosLosetaRotado = new int[5];

		for (int i = 0; i < 4; ++i) {
			print("Dimension 1: " + i + " indice 2: " + (i - factor) % 4);

			ladosLosetaRotado [i] = ladosLoseta [Utils.abs(i - factor) % 4];	
		}
		ladosLosetaRotado [4] = ladosLoseta [4];
		ladosLoseta = ladosLosetaRotado;
	
	
	}



	

}
