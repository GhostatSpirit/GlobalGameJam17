using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTimeRecorder : MonoBehaviour {


	private float instantiateTime;

	// Use this for initialization
	void Start () {
		instantiateTime = Time.time;
		//Debug.Log (instantiateTime);
	}
	
	public float GetTime(){
		return instantiateTime;
	}
}
