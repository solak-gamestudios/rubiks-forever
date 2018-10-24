using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Clearner : MonoBehaviour {

	private List<GameObject> Faces = new List<GameObject>();
	private int[] LineCheck;
	private bool WaitForIt;
	private int Zeros;
	private int Ones;
	private int FaceCount;
	private bool Deleted = true;


	// Use this for initialization
	void Start () {
		
		FaceCount = GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().Matrix;
		LineCheck = new int[FaceCount];
		for (int x = 0; x < LineCheck.Length; x++) {
			LineCheck [x] = 0;
		}

	}
	// Update is called once per frame
	void LateUpdate () {
		for (int i = 0; i < FaceCount; i++){
			if (Input.GetMouseButtonUp (0)) {
				if (GameObject.Find (Faces [i].gameObject.name).gameObject.GetComponent<SpriteRenderer> ().material.color != Color.white
					/*&& Input.GetMouseButtonUp(0)*/) {
					LineCheck [i] = 1;
				} else {
					LineCheck [i] = 0;
				}
			}
		}
		for (int a = 0; a < LineCheck.Length; a++) {
			if (LineCheck [a] == 0) {
				Zeros++;
			} else{
				Ones++;
			}
		}
		if (Ones == FaceCount) {
			GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().PlaySound ();
			if (Deleted) {
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt("Score") + 10);
				PlayerPrefs.SetInt ("TotalScore", PlayerPrefs.GetInt("TotalScore") + 10);
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 5);
                if (FaceCount == 12) {
					Social.ReportScore (PlayerPrefs.GetInt ("TotalScore"), "CgkIs9Hx6tETEAIQDw", (bool success) => { // 6x6x6 Total Score
						// handle success or failure
					});
				} else if (FaceCount == 10) {
					Social.ReportScore (PlayerPrefs.GetInt ("TotalScore"), "CgkIs9Hx6tETEAIQDQ", (bool success) => { // 5x5x5 Total Score
						// handle success or failure
					});
				}
				if (PlayerPrefs.GetInt ("TotalScore") == 1000) {
					Social.ReportProgress("CgkIs9Hx6tETEAIQBg", 100.0f, (bool success) => {
						// handle success or failure
					});
				} else if (PlayerPrefs.GetInt ("TotalScore") == 50000) {
					Social.ReportProgress("CgkIs9Hx6tETEAIQBw", 100.0f, (bool success) => {
						// handle success or failure
					});
				} else if (PlayerPrefs.GetInt ("TotalScore") == 100000) {
					Social.ReportProgress("CgkIs9Hx6tETEAIQCA", 100.0f, (bool success) => {
						// handle success or failure
					});
				} else if (PlayerPrefs.GetInt ("TotalScore") == 1000000) {
					Social.ReportProgress("CgkIs9Hx6tETEAIQCQ", 100.0f, (bool success) => {
						// handle success or failure
					});
				}
				if (PlayerPrefs.GetInt ("HighestScore") < PlayerPrefs.GetInt ("Score")) {
					PlayerPrefs.SetInt ("HighestScore", PlayerPrefs.GetInt ("Score"));
					if (FaceCount == 12) {
						Social.ReportScore (PlayerPrefs.GetInt ("HighestScore"), "CgkIs9Hx6tETEAIQAA", (bool success) => { // 6x6x6 Highest Score
							// handle success or failure
						});
					} else if (FaceCount == 10) {
						Social.ReportScore (PlayerPrefs.GetInt ("HighestScore"), "CgkIs9Hx6tETEAIQCw", (bool success) => { // 5x5x5 Highest Score
							// handle success or failure
						});
					}
					if (PlayerPrefs.GetInt ("HighestScore") == 1000) {
						Social.ReportProgress("CgkIs9Hx6tETEAIQAQ", 100.0f, (bool success) => {
							// handle success or failure
						});
					} else if (PlayerPrefs.GetInt ("HighestScore") == 5000) {
						Social.ReportProgress("CgkIs9Hx6tETEAIQAg", 100.0f, (bool success) => {
							// handle success or failure
						});
					} else if (PlayerPrefs.GetInt ("HighestScore") == 10000) {
						Social.ReportProgress("CgkIs9Hx6tETEAIQAw", 100.0f, (bool success) => {
							// handle success or failure
						});
					} else if (PlayerPrefs.GetInt ("HighestScore") == 50000) {
						Social.ReportProgress("CgkIs9Hx6tETEAIQBA", 100.0f, (bool success) => {
							// handle success or failure
						});
					} else if (PlayerPrefs.GetInt ("HighestScore") == 100000) {
						Social.ReportProgress("CgkIs9Hx6tETEAIQBQ", 100.0f, (bool success) => {
							// handle success or failure
						});
					}
				}
				Deleted = false;
			}
			for (int a = 0; a < Faces.Count; a++) {
				if (GameObject.Find (Faces [a].gameObject.name).gameObject.GetComponent<TableController> ().Cleaned == false) {
					GameObject.Find (Faces [a].gameObject.name).gameObject.GetComponent<TableController> ().Clearner = true;
				}
			}
			for (int a = 0; a < Faces.Count; a++) {
				GameObject.Find (Faces [a].gameObject.name).gameObject.GetComponent<TableController> ().Cleaned = true;
			}
		} else {
			Zeros = 0;
			Ones = 0;
			Deleted = true;
			for (int a = 0; a < FaceCount; a++) {
				LineCheck [a] = 0;
				GameObject.Find (Faces [a].gameObject.name).gameObject.GetComponent<TableController> ().Cleaned = false;
			}
		}
	}
	void OnTriggerEnter (Collider Other){
		Faces.Add(Other.gameObject);
	}
}
/*
if (ColoredFaces >= Faces.Count && Input.GetMouseButtonUp(0)) {
	Debug.Log ("----------");
	Debug.Log ("10 Oldu.");
	for (int a = 0; a < Faces.Count; a++) {
		GameObject.Find (Faces [a].gameObject.name).gameObject.GetComponent<TableController> ().Clearner = true;
	}
} else {
}*/