using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	Button[] botons;
	Text[] nomjug;
	Text[] nummin;
	// Use this for initialization
	void Start () {
		botons = new Button[4];
		nomjug = new Text [4];
		nummin = new Text [4];
		GameObject padre = gameObject.transform.parent.gameObject;
		botons[0] = padre.transform.GetChild (2);
		botons[1] = padre.transform.GetChild (3);
		botons[2] = padre.transform.GetChild (4);
		botons[3] = padre.transform.GetChild (5);
		for (int i = 0; i < 4; ++i) {
			botons[i].GetComponentInChildren<Text> () = new Text(Game.jugadores[i].GetNombre())
		}
		GameObject sidebar = gameObject.transform.GetChild(6).gameObject;
		for (int i = 0; i < 4; ++i) {
			nomjug[i] = sidebar.transform.GetChild(i).GetChild(2);
			nomjug[i] = new Text(Game.jugadores[i].GetNombre());
			nummin[i] = sidebar.transform.GetChild(i).GetChild(1);
			nummin[i] = new Text("x" + Game.jugadores[i].GetSubditos());
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
