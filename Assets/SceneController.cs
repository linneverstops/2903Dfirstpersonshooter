using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	
	[SerializeField] private GameObject enemyPrefab;
	public List<GameObject> enemy_list;
	//used to generate enermy at 5 different locations
	private Vector3[] spawnPositions;
	private GUIStyle style1 = new GUIStyle();
	private int enemy_counter;

	// Use this for initialization
	void Start () {
		this.enemy_counter = 1;
		this.enemy_list = new List<GameObject> ();
		this.spawnPositions = new Vector3[5];
		spawnPositions [0] = new Vector3 (0, 4, 0);
		spawnPositions [1] = new Vector3 (25, 4, 25);
		spawnPositions [2] = new Vector3 (-25, 4, 25);
		spawnPositions [3] = new Vector3 (-25, 4, -25);
		spawnPositions [4] = new Vector3 (25, 4, -25);
		style1.fontSize = 20;
		style1.normal.textColor = Color.green;
	}

	void Update() { 
		if (enemy_list.Count <= 0) {
			for (int i = 0; i < this.enemy_counter; i++) {
				//generate enemies in different locations
				int randomIndex = Random.Range (0, 4);
				GameObject enemy = Instantiate (enemyPrefab) as GameObject;
				enemy_list.Add (enemy);
				enemy.transform.position = this.spawnPositions[randomIndex];
				float angle = Random.Range(0, 360);
				enemy.transform.Rotate(0, angle, 0);
			}
			enemy_counter++;
		}
	}

	void OnGUI() {
		GUI.Label (new Rect (Screen.width - 160, 45, 200, 200), ("Level: " + (enemy_counter - 1)), style1);
		GUI.Label (new Rect (Screen.width - 160, 65, 200, 200), ("Enemies Left: " + enemy_list.Count), style1);
	}
}
