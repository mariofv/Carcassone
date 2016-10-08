using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	Button[] botons;
	Text[] nomjug;
	Text[] nummin;
	public static Image actualTile;
	// Use this for initialization
	void Start () {
		botons = new Button[4];
		nomjug = new Text [4];
		nummin = new Text [4];
		GameObject padre = gameObject.transform.parent.gameObject;
		botons[0] = padre.transform.GetChild (2).GetComponent<Button> ();
		botons[1] = padre.transform.GetChild (3).GetComponent<Button> ();
		botons[2] = padre.transform.GetChild (4).GetComponent<Button> ();
		botons[3] = padre.transform.GetChild (5).GetComponent<Button> ();
		if (Game.jugadores [0] == null) {
			Game.iniJugadores ();
		}
		for (int i = 0; i < 4; ++i) {
			print(Game.jugadores [i].GetNombre ());
			botons [i].GetComponentInChildren<Text> ().text =  (Game.jugadores [i].GetNombre ());
		}
		GameObject sidebar = padre.transform.GetChild(6).gameObject;
		for (int i = 0; i < 4; ++i) {
			nomjug[i] = sidebar.transform.GetChild(i).GetChild(2).GetComponent<Text> ();
			nomjug[i].text = (Game.jugadores[i].GetNombre());
			nummin[i] = sidebar.transform.GetChild(i).GetChild(1).GetComponent<Text> ();
			nummin[i].text = ("x" + Game.jugadores[i].GetSubditos());
		}
		actualTile =  gameObject.transform.parent.gameObject.transform.GetChild (8).GetComponent<Image> ();



	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static void SetActualTile(Sprite tile) {
		actualTile.GetComponent<Image>().sprite = tile;
	}
}
