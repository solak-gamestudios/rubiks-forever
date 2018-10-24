using UnityEngine;
using System.Collections;

public class TableController : MonoBehaviour {

	public bool hitting = false;
	public bool Clearner = false;
	GameObject[] Tracker;
	int TrackerCount;
	GameObject[] Hand;
	int HandCount;
	int HandCount2;
	bool Stop = true;
	bool GoOn = false;
	public bool Cleaned = false;

	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.GetInt("GameOver") == 0 && PlayerPrefs.GetInt("Played") == 1){
			Color color = new Color (PlayerPrefs.GetFloat (gameObject.name + ".r"), 
				PlayerPrefs.GetFloat (gameObject.name + ".g"), 
				PlayerPrefs.GetFloat (gameObject.name + ".b", 1));
			transform.GetComponent<SpriteRenderer> ().material.color = color;
			hitting = true;
			Clearner = false;
		}

	}
	// Update is called once per frame
	void Update () {
		
		Hand = GameObject.FindGameObjectsWithTag ("Boxes");
		HandCount = Hand.Length;

		if (HandCount2 != HandCount || Clearner) {
			
			PlayerPrefs.SetFloat (gameObject.name + ".r", transform.GetComponent<SpriteRenderer>().material.color.r);
			PlayerPrefs.SetFloat (gameObject.name + ".g", transform.GetComponent<SpriteRenderer>().material.color.g);
			PlayerPrefs.SetFloat (gameObject.name + ".b", transform.GetComponent<SpriteRenderer>().material.color.b);
			HandCount2 = Hand.Length;
		}
		if (HandCount2 != HandCount) {
			HandCount2 = Hand.Length;
		}
		
		if (hitting && !Clearner) {
			
			//transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
		} else {
			
			transform.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
		}
		if (Clearner) {
			if (transform.localScale.x <= 0.98f && transform.localScale.x > 0.6f && Stop) {
				transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(0.6f, 0.6f, 1.0f), Time.deltaTime * 12);
			}
			if (transform.localScale.x <= 0.61f || GoOn) {
				transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(0.98f, 0.98f, 1.0f), Time.deltaTime * 12);
				transform.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
				GoOn = true;
				Stop = false;
			}
			if (transform.localScale.x >= 0.97f) {
				Clearner = false;
				transform.localScale = new Vector3(0.98f, 0.98f, 1.0f);
			}
		} else {
			Stop = true;
			GoOn = false;
		}
	}
}
