using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {
	
	[SerializeField] private GameObject tombstonePrefab;
	private GameObject tombstone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI> ();
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		StartCoroutine (Die ());
	}

	private IEnumerator Die() {
		var fromAngle = transform.rotation;
		var toAngle = Quaternion.Euler (transform.eulerAngles + (Vector3.right * 90));
		for (var t = 0f; t < 1; t += Time.deltaTime / 1) {
			transform.rotation = Quaternion.Lerp (fromAngle, toAngle, t);
			yield return null;
		}
		Vector3 deadLocation = this.gameObject.transform.position;
		SceneController controller = GameObject.Find ("Controller").GetComponent<SceneController> ();
		controller.enemy_list.Remove (this.gameObject);
		Destroy (this.gameObject);
		tombstone = Instantiate (tombstonePrefab) as GameObject;
		tombstone.transform.position = new Vector3 (deadLocation.x, 0, deadLocation.z);
	}
}
