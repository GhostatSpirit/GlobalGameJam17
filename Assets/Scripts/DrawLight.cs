using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLight : MonoBehaviour {
	public GameObject lightGO;
	public Transform lightSysTransform;

	public float gapBetweenLights = 0.5f;
	public float lightScale = 1.0f;
	private Vector2 lastLightPos;
	private float gapDistBetweenLights;

	// Use this for initialization
	void Start () {
		lastLightPos = transform.position;
		Vector3 lightExtents = lightGO.GetComponentInChildren<SpriteRenderer>().bounds.extents;
        float radius = Mathf.Max (lightExtents.x, lightExtents.y);
		gapDistBetweenLights = radius * gapBetweenLights;

		// Instantiate the first light
		GameObject newLightGO = Instantiate(lightGO, transform.position, transform.rotation, lightSysTransform);
		Vector3 oldScale = newLightGO.transform.localScale;
		newLightGO.transform.localScale = new Vector3 (oldScale.x * lightScale, oldScale.y * lightScale);
	
	}

	void FixedUpdate(){
		if(lightGO == null){
			return;
		}
		float dist = Vector2.Distance (lastLightPos, transform.position);
		if(dist >= gapDistBetweenLights){
			// we need to instantiate a light here
			GameObject newLightGO = Instantiate(lightGO, transform.position, transform.rotation, lightSysTransform);
			Vector3 oldScale = newLightGO.transform.localScale;
			newLightGO.transform.localScale = new Vector3 (oldScale.x * lightScale, oldScale.y * lightScale);
			lastLightPos = transform.position;
		}	
	}
}
