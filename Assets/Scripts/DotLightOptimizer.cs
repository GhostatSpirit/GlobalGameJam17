using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotLightOptimizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(this.gameObject.layer != other.gameObject.layer){
			return;
		}
		if (transform.GetComponent<InstantiateTimeRecorder> () != null
		   && other.transform.GetComponent<InstantiateTimeRecorder> () != null) {
			//Debug.Log ("trigger hit");
			float thisTime = transform.GetComponent<InstantiateTimeRecorder> ().GetTime ();
			float otherTime = other.transform.GetComponent<InstantiateTimeRecorder> ().GetTime ();
			if (thisTime < otherTime) {
				// Destory black light that hits
				Destroy (this.transform.parent.gameObject);
//				Transform[] ts = this.gameObject.GetComponentsInChildren<Transform> ();
//				foreach (Transform t in ts){
//					if (t.tag == "Shadow"){
//						//destory this shadow
//						Destroy (t.gameObject);
//					}
//						
//				}
			} else if (otherTime < thisTime){
				Destroy (other.transform.parent.gameObject);
//				// Destory black light that hits
//				Transform[] ts = other.gameObject.GetComponentsInChildren<Transform> ();
//				foreach (Transform t in ts){
//					if (t.tag == "Shadow"){
//						//destory this shadow
//						Destroy (t.gameObject);
//					}
//
//				}
			}
		}
	}

}
