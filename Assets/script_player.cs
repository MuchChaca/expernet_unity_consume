using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Collider;
// using System.Collections;

public class script_player : MonoBehaviour {

	int score;
	public Text scoreTxt;

	int bestScore;

	public string score_url = "http://localhost:9090/score/";

	// Use this for initialization
	void Start () {
		score = 0;

		StartCoroutine(loadWeb("http://localhost:9090/score/0/", true));

		scoreTxt.text = "Score : 0";
	}
	
	// Update is called once per frame
	void Update () {
		// 
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "gilet"){
			score++;

			Destroy(other.gameObject, 1);
			
			Debug.Log("[SCORE] " + score);

			scoreTxt.text = "Score : " + score;

			// /score/{playerId}/{score}
			// WWW getClient = new WWW(score_url + score);

			// update best score
			if(score > bestScore) {
				StartCoroutine(loadWeb("http://localhost:9090/score/0/" + score, false));
			}
		}
	}

	IEnumerator loadWeb(String url, Boolean isFetch){ 
		WWW getClient=new WWW(url);
		yield return getClient;
		Debug.Log(getClient.text);
		if(isFetch) {
			Int32.TryParse(getClient.text, out bestScore);
		}
	}
}
