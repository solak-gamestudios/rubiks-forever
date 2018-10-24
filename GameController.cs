using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Transform[] SpawnPoint;
	public GameObject GameOverPanel;
	List<string> BoxesPrefs = new List<string>();
	public GameObject LookAgainPanel;
	public GameObject[] Boxes;
	private GameObject[] BoxesArray;
	//private GameObject[] _1_1;
	private GameObject[] Hand;
	public Text ScoreText;
	int A,B,C;
	public int Matrix; 
	int HandCount;
	int HandCount2;
	bool LookAgain = false;
	int LookAgain2 = 0;
	int TheEnd = 0;
	int RunedCount;
	int RunAgain = 0;
	int Create;
	bool Created;
	int HandCountForRuned;
	public AudioClip Cleaner;

	GameObject[] Tracker;
	int TrackerCount;


	// Use this for initialization
	void Start () {

		BoxesPrefs.Add ("Box_2_1_1");
		BoxesPrefs.Add ("Box_2_1_2");
		BoxesPrefs.Add ("Box_3_1_1");
		BoxesPrefs.Add ("Box_3_1_2");
		BoxesPrefs.Add ("Box_3_1_3");
		BoxesPrefs.Add ("Box_3_1_4");
		BoxesPrefs.Add ("Box_3_2_1");
		BoxesPrefs.Add ("Box_3_2_2");
		BoxesPrefs.Add ("Box_4_1_1");
		BoxesPrefs.Add ("Box_5_1_1");
		BoxesPrefs.Add ("Box_5_1_2");
		BoxesPrefs.Add ("Box_5_1_3");
		BoxesPrefs.Add ("Box_5_1_4");

		Tracker = GameObject.FindGameObjectsWithTag ("Tracker");
		TrackerCount = Tracker.Length;

		Hand = GameObject.FindGameObjectsWithTag ("Boxes");
		HandCount = Hand.Length;
		HandCount2 = Hand.Length;

		if (PlayerPrefs.GetInt ("Played") == 1) {
			for (int x = 0; x < 3; x++) {
				//Debug.Log (PlayerPrefs.GetString ("Box_" + x));
				if (PlayerPrefs.GetString ("Box_" + x) == "") {
					//Cisim Yok.
				} else {
					GameObject ObjectName = (GameObject)Resources.Load(PlayerPrefs.GetString ("Box_" + x));
					Quaternion Rot = Quaternion.Euler (26, -43, ObjectName.transform.rotation.z);
					Instantiate (ObjectName, SpawnPoint [x].position, Rot);
				}
			}
		}
		PlayerPrefs.SetInt ("Played", 1);
		
	}
	public void PlaySound(){
		GetComponent<AudioSource>().clip = Cleaner;
		GetComponent<AudioSource> ().Play ();
	}
	void C_Box_2_1_1(){
		PlayerPrefs.SetInt ("Box_2_1_1", 1);
		//Debug.Log ("C_Box_2_1_1");
	}
	void C_Box_2_1_1_(){
		PlayerPrefs.SetInt ("Box_2_1_1", 0);
		//Debug.Log ("C_Box_2_1_1");
	}
	void C_Box_2_1_2(){
		PlayerPrefs.SetInt ("Box_2_1_2", 1);
		//Debug.Log ("C_Box_2_1_2");
	}
	void C_Box_2_1_2_(){
		PlayerPrefs.SetInt ("Box_2_1_2", 0);
		//Debug.Log ("C_Box_2_1_2");
	}
	void C_Box_3_1_1(){
		PlayerPrefs.SetInt ("Box_3_1_1", 1);
		//Debug.Log ("C_Box_3_1_1");
	}
	void C_Box_3_1_1_(){
		PlayerPrefs.SetInt ("Box_3_1_1", 0);
		//Debug.Log ("C_Box_3_1_1");
	}
	void C_Box_3_1_2(){
		PlayerPrefs.SetInt ("Box_3_1_2", 1);
		//Debug.Log ("C_Box_3_1_2");
	}
	void C_Box_3_1_2_(){
		PlayerPrefs.SetInt ("Box_3_1_2", 0);
		//Debug.Log ("C_Box_3_1_2");
	}
	void C_Box_3_1_3(){
		PlayerPrefs.SetInt ("Box_3_1_3", 1);
		//Debug.Log ("C_Box_3_1_3");
	}
	void C_Box_3_1_3_(){
		PlayerPrefs.SetInt ("Box_3_1_3", 0);
		//Debug.Log ("C_Box_3_1_3");
	}
	void C_Box_3_1_4(){
		PlayerPrefs.SetInt ("Box_3_1_4", 1);
		//Debug.Log ("C_Box_3_1_4");
	}
	void C_Box_3_1_4_(){
		PlayerPrefs.SetInt ("Box_3_1_4", 0);
		//Debug.Log ("C_Box_3_1_4");
	}
	void C_Box_3_2_1(){
		PlayerPrefs.SetInt ("Box_3_2_1", 1);
		//Debug.Log ("C_Box_3_2_1");
	}
	void C_Box_3_2_1_(){
		PlayerPrefs.SetInt ("Box_3_2_1", 0);
		//Debug.Log ("C_Box_3_2_1");
	}
	void C_Box_3_2_2(){
		PlayerPrefs.SetInt ("Box_3_2_2", 1);
		//Debug.Log ("C_Box_3_2_2");
	}
	void C_Box_3_2_2_(){
		PlayerPrefs.SetInt ("Box_3_2_2", 0);
		//Debug.Log ("C_Box_3_2_2");
	}
	void C_Box_4_1_1(){
		PlayerPrefs.SetInt ("Box_4_1_1", 1);
		//Debug.Log ("C_Box_4_1_1");
	}
	void C_Box_4_1_1_(){
		PlayerPrefs.SetInt ("Box_4_1_1", 0);
		//Debug.Log ("C_Box_4_1_1");
	}
	void C_Box_5_1_1(){
		PlayerPrefs.SetInt ("Box_5_1_1", 1);
		//Debug.Log ("C_Box_5_1_1");
	}
	void C_Box_5_1_1_(){
		PlayerPrefs.SetInt ("Box_5_1_1", 0);
		//Debug.Log ("C_Box_5_1_1");
	}
	void C_Box_5_1_2(){
		PlayerPrefs.SetInt ("Box_5_1_2", 1);
		//Debug.Log ("C_Box_5_1_2");
	}
	void C_Box_5_1_2_(){
		PlayerPrefs.SetInt ("Box_5_1_2", 0);
		//Debug.Log ("C_Box_5_1_2");
	}
	void C_Box_5_1_3(){
		PlayerPrefs.SetInt ("Box_5_1_3", 1);
		//Debug.Log ("C_Box_5_1_3");
	}
	void C_Box_5_1_3_(){
		PlayerPrefs.SetInt ("Box_5_1_3", 0);
		//Debug.Log ("C_Box_5_1_3");
	}
	void C_Box_5_1_4(){
		PlayerPrefs.SetInt ("Box_5_1_4", 1);
		//Debug.Log ("C_Box_5_1_4");
	}
	void C_Box_5_1_4_(){
		PlayerPrefs.SetInt ("Box_5_1_4", 0);
		//Debug.Log ("C_Box_5_1_4");
	}
	void Update(){

		A = 0; B = 0; C = 0;
		BoxesArray = GameObject.FindGameObjectsWithTag ("Boxes");
		int BoxesCount = BoxesArray.Length;
		if (BoxesCount == 0 && PlayerPrefs.GetInt ("GameOver") == 0) {
			A = Random.Range (0, 14); 
			B = Random.Range (0, 14);
			C = Random.Range (0, 14); 
			if (Boxes [A].gameObject.name.Substring (0, 7) != Boxes [B].gameObject.name.Substring (0, 7)) {
				Create++;
			}
			if (Boxes [A].gameObject.name.Substring (0, 7) != Boxes [C].gameObject.name.Substring (0, 7)) {
				Create++;
			}
			if (Boxes [B].gameObject.name.Substring (0, 7) != Boxes [C].gameObject.name.Substring (0, 7)) {
				Create++;
			}
			if (Create == 3) {
				Quaternion AZRot = Quaternion.Euler (26, -43, Boxes [A].transform.rotation.z);
				Quaternion BZRot = Quaternion.Euler (26, -43, Boxes [B].transform.rotation.z);
				Quaternion CZRot = Quaternion.Euler (26, -43, Boxes [C].transform.rotation.z);

				Instantiate (Boxes [A], SpawnPoint [0].position, AZRot);
				Instantiate (Boxes [B], SpawnPoint [1].position, BZRot);
				Instantiate (Boxes [C], SpawnPoint [2].position, CZRot);
				Create = 0;
				Call ();
				Created = true;

			} else {
				Create = 0;
			}
		}
		ScoreText.text = PlayerPrefs.GetInt ("Score").ToString ();

		Hand = GameObject.FindGameObjectsWithTag ("Boxes");
		HandCount = Hand.Length;

	}
	// Update is called once per frame
	void LateUpdate () {
		for (int x = 0; x < 3; x++) {
			if (x >= HandCount) {
				PlayerPrefs.SetString ("Box_" + x, "");
			} else {
                if (Hand[x] == null)
                {
                    Debug.Log("asda");
                }
                else {
                    PlayerPrefs.SetString("Box_" + x, Hand[x].gameObject.name.Substring(0, 9));
                }
			}
		}
		for (int a = 0; a < TrackerCount; a++) {
			HandCountForRuned = HandCount;
			for (int x = 0; x < HandCount; x++) {
				if (Hand [x] == null) {
					//Cisim Yok.
				} else {
					if (Hand [x].gameObject.name.Substring (0, 9) == "Box_1_1_1") {
						HandCountForRuned--;
					}
				}
			}
			if (Tracker [a].gameObject.GetComponent<CheckerLiner> ().Runed) {
				RunedCount++;
			}
		}
		if ((RunedCount == HandCountForRuned) && ((HandCount2 != HandCount) || Created) && Hand.Length != 0) {
			Created = false;
			HandCount2 = Hand.Length;
			for (int x = 0; x < HandCount; x++) {
				if (Hand [x] == null) {
					//Cisim Yok.
				} else {
					string BoxName = Hand [x].gameObject.name.Substring (0, 9);
					if (Hand [x].gameObject.name.Substring (0, 9) != "Box_1_1_1") {
						//Debug.Log (BoxName + ": " + PlayerPrefs.GetInt (BoxName));
						for (int z = 0; z < TrackerCount; z++) {
							Tracker [z].gameObject.GetComponent<CheckerLiner> ().FreePass = true;
						}
						for (int v = 0; v < 13; v++) {
							if (PlayerPrefs.GetInt (BoxesPrefs[v]) == 0 && BoxName == BoxesPrefs[v]) {
								TheEnd++;
								if (TheEnd == HandCount) {
									PlayerPrefs.SetInt ("GameOver", 1);
									GameOverPanel.gameObject.SetActive (true);
									LookAgainPanel.gameObject.SetActive (true);
									PlayerPrefs.SetInt ("Score", 0);
									PlayerPrefs.SetInt ("Played", 0);
								}
							} else {
								//TheEnd = 0;
							}
						}
					}
				}
			}
			LookAgain = false;
			for (int a = 0; a < TrackerCount; a++) {
				Tracker [a].gameObject.GetComponent<CheckerLiner> ().Runed = false;
			}
		}
		HandCountForRuned = 0;
		RunedCount = 0;
		TheEnd = 0;
		/*
			PlayerPrefs.SetInt ("Box_1_1_1", 1);
			PlayerPrefs.SetInt ("Box_2_1_1", 0);
			PlayerPrefs.SetInt ("Box_2_1_2", 0);
			PlayerPrefs.SetInt ("Box_3_1_1", 0);
			PlayerPrefs.SetInt ("Box_3_1_2", 0);
			PlayerPrefs.SetInt ("Box_3_1_3", 0);
			PlayerPrefs.SetInt ("Box_3_1_4", 0);
			PlayerPrefs.SetInt ("Box_3_2_1", 0);
			PlayerPrefs.SetInt ("Box_3_2_2", 0);
			PlayerPrefs.SetInt ("Box_4_1_1", 0);
			PlayerPrefs.SetInt ("Box_5_1_1", 0);
			PlayerPrefs.SetInt ("Box_5_1_2", 0);
			PlayerPrefs.SetInt ("Box_5_1_3", 0);
			PlayerPrefs.SetInt ("Box_5_1_4", 0);
			*/
		if (HandCount2 != HandCount) {
			HandCount2 = Hand.Length;
		}
	}
	void Call(){
		Hand = GameObject.FindGameObjectsWithTag ("Boxes");
		HandCount = Hand.Length;
	}
}
