using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	int public grau (int i, int j){
		if(i j) return (i-j)*90;
		else return (j-i)*(-90);
}
