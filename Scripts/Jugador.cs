using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour {
	
	public int puntos;
	public int subditos;
	public string nombre;
	
	// Use this for initialization
	void Start () {
		puntos = 0;
		subditos = 8;
		nombre = "Jugador";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int GetPuntos() {
		return puntos;
	}
	public void SetPuntos(int i) {
		puntos = i;
	}
	
	public int GetSubditos() {
		return subditos;	
	} 
	public void SetSubditos(int i) {
		subditos = i;	
	}
	
	public string GetNombre() {
		return nombre;	
	}
	public void SetNombre(string i) {
		nombre = i;
	}
	//Si tienes subdito disponible lo resta, sino avisa de ERROR
	public void ColocaSubdito() {
		if(subditos > 0) --subditos;
		else print("No tienes subditos");
	}
	
	//Aumenta los puntos al devolver un subdito a la mano
	public void aumentaPuntos(int puntuacion) {
		puntos += puntuacion;
		++subditos;
	}
}
