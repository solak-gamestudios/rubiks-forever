using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	private Vector3 Dist;
	RaycastHit hit;
	float PosX;
	float PosY;
	bool ForCheck;
	private bool CornerCheck;
	public bool ErrorShit;
	private bool DestroyCheck = false;
	private bool DestroyCheck2;
	private Vector3 OldPosition;
	private Quaternion OldRotation;
	private Vector3 OldScale;
	private bool IfItsHitBefore;

	// Use this for initialization
	void Start () {
		OldPosition = transform.position;
		OldRotation = transform.rotation;
		OldScale = transform.GetChild (0).transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		DestroyCheck2 = false;
		//İz Düşümü
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 20;
		Debug.DrawRay (transform.position, forward, Color.black);
		if (Physics.Raycast (transform.position, forward, out hit)) {
			IfItsHitBefore = true;
			transform.GetChild (0).transform.gameObject.SetActive (false);
			bool ForCheck = true;
			int children = transform.GetChild (1).childCount;
			for (int i = 0; i < children; ++i) {
				if (transform.GetChild (1).GetChild (i).GetComponent<Marker> ().ItsHit 
					&& transform.GetChild (1).GetChild (i).GetComponent<Marker> ().ColorCheck) {
				}else{
					ForCheck = false;
				}
			}
			if (ForCheck) {
				for (int i = 0; i < children; ++i) {
					transform.GetChild (1).GetChild (i).SendMessage ("Drawit");
					DestroyCheck = true;
					DestroyCheck2 = transform.GetChild (1).GetChild (0).GetComponent<Marker> ().MarkCheck;
				}
			} else {
				for (int i = 0; i < children; ++i) {
					transform.GetChild (1).GetChild (i).SendMessage ("DoNotDrawit");
				}
				transform.GetChild (0).transform.gameObject.SetActive (true);
			}
			if (hit.collider.gameObject.tag == "Face-1") {
				PlayerPrefs.SetInt ("Played", 1);
				//Değişmezler
				transform.GetChild (0).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
				transform.GetChild (1).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
				transform.GetChild (1).transform.position = hit.collider.gameObject.transform.position;
				ErrorShit = true;
				//
				//Değişkenler
				transform.GetChild (0).transform.rotation = Quaternion.Lerp
					(transform.GetChild (0).transform.rotation, hit.collider.gameObject.transform.rotation, Time.deltaTime * 14);
				transform.GetChild (1).transform.rotation = hit.collider.gameObject.transform.rotation;
				if (transform.gameObject.name.StartsWith ("Box_3_1_")
					|| transform.gameObject.name.StartsWith ("Box_5_1_")) {
					transform.GetChild (0).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
					transform.GetChild (1).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
				}
				//

			} else if (hit.collider.gameObject.tag == "Face-2") {
				//Değişmezler
				transform.GetChild (0).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
				transform.GetChild (1).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
				transform.GetChild (1).transform.position = hit.collider.gameObject.transform.position;
				ErrorShit = true;
				//
				//Değişkenler
				transform.GetChild (0).transform.rotation = Quaternion.Lerp
					(transform.GetChild (0).transform.rotation, hit.collider.gameObject.transform.rotation, Time.deltaTime * 14);
				transform.GetChild (1).transform.rotation = hit.collider.gameObject.transform.rotation;
				if (transform.gameObject.name.StartsWith ("Box_3_1_")
					|| transform.gameObject.name.StartsWith ("Box_5_1_")) {
					transform.GetChild (0).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
					transform.GetChild (1).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
				}
				//

			} else if (hit.collider.gameObject.tag == "Face-3") {
				//Değişmezler
				transform.GetChild (0).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
				transform.GetChild (1).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
				transform.GetChild (1).transform.position = hit.collider.gameObject.transform.position;
				ErrorShit = true;
				//
				//Değişkenler
				if (transform.gameObject.name.StartsWith ("Box_2_1_") 
					|| transform.gameObject.name.StartsWith ("Box_3_1_") 
					|| transform.gameObject.name.StartsWith ("Box_3_2") 
					|| transform.gameObject.name.StartsWith ("Box_3_2") 
					|| transform.gameObject.name.StartsWith ("Box_3_1_2") 
					|| transform.gameObject.name.StartsWith ("Box_3_1_3") 
					|| transform.gameObject.name.StartsWith ("Box_3_1_4") 
					|| transform.gameObject.name.StartsWith ("Box_5_1_") 
					|| transform.gameObject.name.StartsWith ("Box_5_1_2") 
					|| transform.gameObject.name.StartsWith ("Box_5_1_3") 
					|| transform.gameObject.name.StartsWith ("Box_5_1_4") ) {
					transform.GetChild (0).transform.localEulerAngles = new Vector3 (-116.019f, -0.164001f, 133.245f);
					transform.GetChild (1).transform.localEulerAngles = new Vector3 (-116.019f, -0.164001f, 133.245f);
					if (transform.gameObject.name.StartsWith ("Box_3_1_") 
						|| transform.gameObject.name.StartsWith ("Box_5_1_")) {
						transform.GetChild (0).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
						transform.GetChild (1).transform.localScale = new Vector3 (-0.9f, 0.9f, 1);
					}
				}
				else {
					transform.GetChild (0).transform.rotation = Quaternion.Lerp
						(transform.GetChild (0).transform.rotation, hit.collider.gameObject.transform.rotation, Time.deltaTime * 14);
					transform.GetChild (1).transform.rotation = hit.collider.gameObject.transform.rotation;
				}

			} 
		} else {
			transform.GetChild (0).transform.localScale = OldScale;
			transform.GetChild (0).transform.gameObject.SetActive (true);
			if (IfItsHitBefore){
				//transform.localScale = OldScale;
			}
			//transform.GetChild (0).transform.localScale = new Vector3 (0.9f, 0.9f, 1);
			ErrorShit = false;
			int children = transform.childCount;
			for (int i = 0; i < children; ++i) {
				transform.GetChild (i).transform.rotation = transform.rotation;
			}
		}
	}
	//Pc Kontrolleri

	void OnMouseDown(){
        if (PlayerPrefs.GetInt("GameOver") == 0)
        {
            Dist = Camera.main.WorldToScreenPoint(transform.position);
            PosX = Input.mousePosition.x;
            PosY = Input.mousePosition.y;
            //transform.localPosition = Input.mousePosition;
        }
    }

	void OnMouseDrag(){
        if (PlayerPrefs.GetInt("GameOver") == 0)
        {
            Vector3 CurPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Dist.z);
            Vector3 WorldPos = Camera.main.ScreenToWorldPoint(CurPos);
            //transform.localPosition = WorldPos;
            transform.position = Vector3.Lerp(transform.position, new Vector3(WorldPos.x, WorldPos.y + 8, WorldPos.z), Time.deltaTime * 20);
            //transform.position = WorldPos;
        }
	}
	void OnMouseUp(){
		if (DestroyCheck && DestroyCheck2) {
			Destroy (gameObject);
		} else {
			transform.position = OldPosition;
			transform.rotation = OldRotation;
			transform.GetChild (0).transform.localScale = OldScale;
		}
	}
}
