using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_cube : MonoBehaviour {

	Vector3 axeY;

	// Use this for initialization
	void Start () {
		// Debug.Log("Hello starter !");

		axeY = new Vector3(0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Hello updater !");

		gameObject.transform.Rotate(axeY, 1f);
	}
}
