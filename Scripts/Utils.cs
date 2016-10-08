using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static int abs (int x) {
		if (x >= 0)
			return x;
		return -x;
	}

	public static int opuesto(int dir) {
		return (dir + 2) % 4;
	}

	public static int grau (int i, int j) {
		if(i > j) return (i-j)*90;
		else if (i < j) return (j-i)*(-90);
		return 0;
	}

}
