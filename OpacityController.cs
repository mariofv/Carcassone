using UnityEngine;
using System.Collections;

public class OpacityController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<CanvasRenderer> ().SetAlpha (10.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
