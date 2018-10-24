using UnityEngine;
using System.Collections;

public class CheckerLiner : MonoBehaviour {

	private GameObject[] Face_1;
	private GameObject[] Face_2;
	private GameObject[] Face_3;
	int FacesCount_1;
	int FacesCount_2;
	int FacesCount_3;
	int CountChild;
	int stop;
	int last;
	string SendName;
	private GameObject[] Hand;
	int HandCount;
	int HandCount2;
	int GoOn;
	public bool FreePass;
	public bool Runed;

	int F1R1;int F1R2;int F1R3;int F1R4;
	int F2R1;int F2R2;int F2R3;int F2R4;
	int F3R1;int F3R2;int F3R3;int F3R4;

	// Use this for initialization
	void Start () {
		Face_1 = GameObject.FindGameObjectsWithTag ("Face-1");
		Face_2 = GameObject.FindGameObjectsWithTag ("Face-2");
		Face_3 = GameObject.FindGameObjectsWithTag ("Face-3");
		FacesCount_1 = Face_1.Length;
		FacesCount_2 = Face_2.Length;
		FacesCount_3 = Face_3.Length;
		CountChild = transform.GetChild (0).GetChild (0).childCount;

		Hand = GameObject.FindGameObjectsWithTag ("Boxes");
		HandCount = Hand.Length;
		HandCount2 = Hand.Length;

		if (transform.gameObject.name.StartsWith ("C_Box_2_1") || transform.gameObject.name.StartsWith ("C_Box_3_2")) {
			stop = 2;
		} else if (transform.gameObject.name.StartsWith ("C_Box_4")) {
			stop = 1;
		} else if (transform.gameObject.name.StartsWith ("C_Box_3_1") || transform.gameObject.name.StartsWith ("C_Box_5_1")) {
			stop = 4;
		}
		if (transform.gameObject.name.StartsWith ("C_Box_1")) {
			last = 1;
		} else if (transform.gameObject.name.StartsWith ("C_Box_2")) {
			last = 2;
		} else if (transform.gameObject.name.StartsWith ("C_Box_3")) {
			last = 3;
		} else if (transform.gameObject.name.StartsWith ("C_Box_4")) {
			last = 4;
		} else if (transform.gameObject.name.StartsWith ("C_Box_5")) {
			last = 5;
		}
	}
	
	// Update is called once per frame
	void Update(){
		//if (HandCount2 != HandCount) {
			Hand = GameObject.FindGameObjectsWithTag ("Boxes");
			HandCount = Hand.Length;
			for (int x = 0; x < HandCount; x++) {
				if ("C_" + Hand [x].gameObject.name.Substring (0, 7) == transform.gameObject.name) {
					GoOn++;
					//Debug.Log ("Eldekiler: " + Hand [x].gameObject.name);
					//Debug.Log (transform.gameObject.name + ": GoOn++");
				}
			}
		//}
	}
	void LateUpdate () {
		if (GoOn > 0 && HandCount != 0) {
			//Debug.Log (transform.gameObject.name + ": GoOn.");
			//Debug.Log (HandCount2 + " " + HandCount);
			if (HandCount2 != HandCount) {
				HandCount2 = Hand.Length;
				//Debug.Log (transform.gameObject.name + ": Kontrol Edildi.");
                
				F1R1 = 0;F1R2 = 0;F1R3 = 0;F1R4 = 0;
				for (int a = 0; a < FacesCount_1; a++) { // 1. Yüz
                    //transform.position = new Vector3(Face_1[a].transform.position.x, Face_1[a].transform.position.y, -2f);
                    transform.position = Face_1[a].transform.position;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    for (int b = 0; b < stop; b++) { 
						if (b == 0) {
							if (transform.gameObject.name.StartsWith ("C_Box_3_1") || transform.gameObject.name.StartsWith ("C_Box_5_1")) {
								transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, Face_1 [a].transform.rotation.y, 0);
							} else {
								transform.rotation = Face_1 [a].transform.rotation;
							}
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								//Debug.Log (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ());
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F1R1++;
                                }
							}
						}
						if (b == 1) {
							if (transform.gameObject.name.StartsWith ("C_Box_3_1") || transform.gameObject.name.StartsWith ("C_Box_5_1")) {
								transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, Face_1 [a].transform.rotation.y, 270);
							} else {
								transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, Face_1 [a].transform.rotation.y, 90);
							}
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F1R2++;
                                }
							}
						}
						if (b == 2) {
							transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, Face_1 [a].transform.rotation.y, 90);
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F1R3++;
                                }
							}
						}
						if (b == 3) {
							transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, Face_1 [a].transform.rotation.y, 180);
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F1R4++;
                                }
							}
						}
					}
				}
                
				F2R1 = 0;F2R2 = 0;F2R3 = 0;F2R4 = 0;
				for (int a = 0; a < FacesCount_2; a++) { // 2. Yüz
					transform.position = Face_2 [a].transform.position;
					transform.rotation = Quaternion.Euler(0, 90, 0);
					for (int b = 0; b < stop; b++) { 
						if (b == 0) {
							if (transform.gameObject.name.StartsWith ("C_Box_3_1") || transform.gameObject.name.StartsWith ("C_Box_5_1")) {
								transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, 90, 270);
							} else {
								transform.rotation = Quaternion.Euler(0, 90, 0);
							}
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F2R1++;
								}
							}
						}
						if (b == 1) {
							if (transform.gameObject.name.StartsWith ("C_Box_3_1") || transform.gameObject.name.StartsWith ("C_Box_5_1")) {
								transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, 90, 0);
							} else {
								transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, 90, 90);
							}
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F2R2++;
								}
							}
						}
						if (b == 2) {
							transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, 90, 180);
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F2R3++;
								}
							}
						}
						if (b == 3) {
							transform.rotation = Quaternion.Euler(Face_1 [a].transform.rotation.x, 90, 90);
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F2R4++;
								}
							}
						}
					}
				}
                
				F3R1 = 0;F3R2 = 0;F3R3 = 0;F3R4 = 0;
				for (int a = 0; a < FacesCount_3; a++) { // 3. Yüz
					transform.position = Face_3 [a].transform.position;
					transform.rotation = Quaternion.Euler(270, 0, 0);
					for (int b = 0; b < stop; b++) { 
						if (b == 0) {
							if (transform.gameObject.name.StartsWith ("C_Box_3_1") || transform.gameObject.name.StartsWith ("C_Box_5_1")) {
								transform.rotation = Quaternion.Euler(270, Face_1 [a].transform.rotation.y, 0);
							} else {
								transform.rotation = Quaternion.Euler(270, 0, 90);
							}
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F3R1++;
                                }
							}
						}
						if (b == 1) {
							if (transform.gameObject.name.StartsWith ("C_Box_3_1") || transform.gameObject.name.StartsWith ("C_Box_5_1")) {
								transform.rotation = Quaternion.Euler(270, Face_1 [a].transform.rotation.y, 90);
							} else {
								transform.rotation = Quaternion.Euler(270, Face_1 [a].transform.rotation.y, 0);
							}
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F3R2++;
                                }
							}
						}
						if (b == 2) {
							transform.rotation = Quaternion.Euler(270, Face_1 [a].transform.rotation.y, 270);
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F3R3++;
                                }
							}
						}
						if (b == 3) {
							transform.rotation = Quaternion.Euler(270, Face_1 [a].transform.rotation.y, 180);
							int x = 0;
							for (int c = 0; c < CountChild; c++) {
								if (transform.GetChild (0).GetChild (0).GetChild (c).GetComponent<LookForPlace> ().CheckSpace ()) {
									x++;
								}
								if (x == last) {
									F3R4++;
                                }
							}
						}
					}
				}
                
				Runed = true;
				FreePass = false;
				if (transform.gameObject.name.StartsWith ("C_Box_2")) {
					if (F1R1 >= 1 || F2R1 >= 1 || F3R1 >= 1) {
						SendName = transform.gameObject.name + "_1";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_1: " + F1R1 + " " + F2R1 + " " + F3R1);
                    }
                    else{
						SendName = transform.gameObject.name + "_1_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                    }
					if (F1R2 >= 1 || F2R2 >= 1 || F3R2 >= 1) {
						SendName = transform.gameObject.name + "_2";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_2: " + F1R2 + " " + F2R2 + " " + F3R2);
                    }
                    else{
						SendName = transform.gameObject.name + "_2_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
					}
				}
				if (transform.gameObject.name.StartsWith ("C_Box_3_1")) {
					if (F1R1 >= 1 || F2R1 >= 1 || F3R1 >= 1) {
						SendName = transform.gameObject.name + "_1";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_1: " + F1R1 + " " + F2R1 + " " + F3R1);
                    }
                    else{
						SendName = transform.gameObject.name + "_1_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
					}
					if (F1R2 >= 1 || F2R2 >= 1 || F3R2 >= 1) {
						SendName = transform.gameObject.name + "_2";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_2: " + F1R2 + " " + F2R2 + " " + F3R2);
                    }
                    else{
						SendName = transform.gameObject.name + "_2_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
					}
					if (F1R3 >= 1 || F2R3 >= 1 || F3R3 >= 1) {
						SendName = transform.gameObject.name + "_3";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_3: " + F1R3 + " " + F2R3 + " " + F3R3);
                    }
                    else{
						SendName = transform.gameObject.name + "_3_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
					}
					if (F1R4 >= 1 || F2R4 >= 1 || F3R4 >= 1) {
						SendName = transform.gameObject.name + "_4";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_4: " + F1R4 + " " + F2R4 + " " + F3R4);
                    }
                    else{
						SendName = transform.gameObject.name + "_4_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
					}
				}
				if (transform.gameObject.name.StartsWith ("C_Box_3_2")) {
					if (F1R1 >= 1 || F2R1 >= 1 || F3R1 >= 1) {
						SendName = transform.gameObject.name + "_1";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_1: " + F1R1 + " " + F2R1 + " " + F3R1);
                    }
                    else{
						SendName = transform.gameObject.name + "_1_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
					}
					if (F1R2 >= 1 || F2R2 >= 1 || F3R2 >= 1) {
						SendName = transform.gameObject.name + "_2";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_2: " + F1R2 + " " + F2R2 + " " + F3R2);
                    }
                    else{
						SendName = transform.gameObject.name + "_2_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
					}
				}
				if (transform.gameObject.name.StartsWith ("C_Box_4")) {
					if (F1R1 >= 1 || F2R1 >= 1 || F3R1 >= 1) {
						SendName = transform.gameObject.name + "_1";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_1: " + F1R1 + " " + F2R1 + " " + F3R1);
                    }
                    else
                    {
						SendName = transform.gameObject.name + "_1_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
					}
				}
				if (transform.gameObject.name.StartsWith ("C_Box_5")) {
					if (F1R1 >= 1 || F2R1 >= 1 || F3R1 >= 1) {
						SendName = transform.gameObject.name + "_1";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
						//Debug.Log ("_1: " + F1R1 +" "+ F2R1 +" "+ F3R1);
					}else{
						SendName = transform.gameObject.name + "_1_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                    }
					if (F1R2 >= 1 || F2R2 >= 1 || F3R2 >= 1) {
						SendName = transform.gameObject.name + "_2";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_2: " + F1R2 + " " + F2R2 + " " + F3R2);
                    }
                    else{
						SendName = transform.gameObject.name + "_2_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                    }
					if (F1R3 >= 1 || F2R3 >= 1 || F3R3 >= 1) {
						SendName = transform.gameObject.name + "_3";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_3: " + F1R3 + " " + F2R3 + " " + F3R3);
                    }
                    else{
						SendName = transform.gameObject.name + "_3_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                    }
					if (F1R4 >= 1 || F2R4 >= 1 || F3R4 >= 1) {
						SendName = transform.gameObject.name + "_4";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                        //Debug.Log("_4: " + F1R4 + " " + F2R4 + " " + F3R4);
                    }
                    else{
						SendName = transform.gameObject.name + "_4_";
						GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().SendMessage (SendName);
                    }
				}
			}
			GoOn = 0;
		}
		if (HandCount2 != HandCount) {
			HandCount2 = Hand.Length;
		}
	}
}
