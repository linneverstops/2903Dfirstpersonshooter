using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
	private GUIStyle style1 = new GUIStyle();
	private GUIStyle style2 = new GUIStyle();
	private int xCoor;
	private int yCoor;
	private int xsteps;
	private int ysteps;
	public int _health;

	void Start () {
		_health = 5;
		style1.fontSize = 25;
		style1.normal.textColor = Color.green;
		style2.fontSize = 35;
		style2.normal.textColor = Color.red;
		xCoor = 300;
		yCoor = 300;
		xsteps = 1;
		ysteps = 1;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Hurt(int damage) {
		_health -= damage;
	}

	void OnGUI() {
		if (_health <= 0) {
			GUI.Label (new Rect (xCoor, yCoor, 250, 30), "You Have Died!", style2);
			if (xCoor <= 0 || xCoor + 250 >= Screen.width) {
				xsteps *= -1;
			}
			if (yCoor <= 0 || yCoor + 30 >= Screen.height) {
				ysteps *= -1;
			}
			xCoor += xsteps;
			yCoor += ysteps;
			GUI.Label (new Rect (Screen.width - 160, 20, 200, 200), ("Game Over"), style1);
		} 
		else {
			GUI.Label (new Rect (Screen.width - 160, 20, 200, 200), ("Health: " + _health), style1);
		}
	}
}
