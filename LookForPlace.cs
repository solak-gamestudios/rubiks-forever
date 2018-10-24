using UnityEngine;
using System.Collections;

public class LookForPlace : MonoBehaviour {

	public bool ColorCheck;
	public RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//İz Düşümü

	}

	public bool CheckSpace(){
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 10;
		Debug.DrawRay (transform.position, forward, Color.black);
		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (hit.collider.gameObject.name.StartsWith ("Face")) {
                Color BoxColor = hit.collider.gameObject.GetComponent<Renderer>().material.color;
				if (BoxColor [0] == 1 && BoxColor [1] == 1 && BoxColor [2] == 1 && BoxColor [3] == 1) {
					return (true);
				} else {
					return (false);
				}
			} else {
				return(false);
			}
		} else {
			return (false);
		}
	}
}
