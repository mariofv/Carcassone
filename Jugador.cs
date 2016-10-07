using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour {
	
	public int puntos;
	public int subditos;
	
	// Use this for initialization
	void Start () {
		puntos = 0;
		subditos = 8;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Si tienes subdito disponible lo resta, sino avisa de ERROR
	public void ColocaSubdito() {
		if(subditos > 0) --subditos;
		else print("No tienes subditos");
	}
}
