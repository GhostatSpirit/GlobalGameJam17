using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInitCoolDown : MonoBehaviour {
	public float initCoolDownDelay = 1.5f;

	bool coolDown = false;

	// Use this for initialization
	void Start () {
		Invoke ("CoolDown", initCoolDownDelay);
	}


	void CoolDown(){
		coolDown = true;
	}

	public bool isCooledDown(){
		return coolDown;
	}
}
