using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

	private bool Draw = false;
	public bool ItsHit;
	public bool ColorCheck;
	public RaycastHit hit;
	public bool MarkCheck;




	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		//İz Düşümü
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 40;
		Debug.DrawRay (transform.position, forward, Color.black);
		Color ParentColor = transform.parent.parent.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().material.color;
		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (!hit.collider.gameObject.name.StartsWith ("Box") && hit.collider.gameObject.tag != "Lines") {
				Color BoxColor = hit.collider.transform.gameObject.GetComponent<SpriteRenderer> ().material.color;
				if (BoxColor [0] == 1 && BoxColor [1] == 1 && BoxColor [2] == 1 && BoxColor [3] == 1) {
					ColorCheck = true;
				} else {
					ColorCheck = false;
				}
				ItsHit = true;
				if (Draw && ColorCheck && transform.parent.parent.GetComponent<Movement>().ErrorShit) {
					hit.transform.gameObject.GetComponent<SpriteRenderer> ().material.color = new Color (ParentColor [0], ParentColor [1], ParentColor [2], ParentColor [3]);
					if (Input.GetMouseButtonUp (0)) {
						MarkCheck = false;
						hit.transform.gameObject.GetComponent<TableController>().hitting = true;
					} else {
						MarkCheck = true;
						hit.transform.gameObject.GetComponent<TableController>().hitting = false;
					}
				}
			} else {
				ItsHit = false;
			}
		} else {
			ItsHit = false;
		}
	}
	void Drawit(){
		Draw = true;
	}
	void DoNotDrawit(){
		Draw = false;
	}
}
