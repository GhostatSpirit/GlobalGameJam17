using UnityEngine;
using System.Collections;


public enum Player {Player1, Player2};

// Attach on an FOWSystem Object
// All FOWGrids will be instatiated as its children
public class GridSystemControl : MonoBehaviour {
	
	public float gridSizeFactor = 2.0f;
	public float gridGapFactor = 0.4f;
	public GameObject Player1Light;
	public GameObject Player2Light;

	Bounds bounds;
	float gridSize;
	float gridGap;

	// Use this for initialization
	void Start () {
		// get the properties from the SpriteRenderer bound
		bounds = GetComponent<SpriteRenderer> ().bounds;
		// Disable the SpriteRenderer
		GetComponent<SpriteRenderer> ().enabled = false;

		// get the actual grid size and grid gap
		SpriteRenderer lightSR = Player1Light.GetComponentInChildren<SpriteRenderer>();
		if(lightSR == null){
			this.gameObject.SetActive (false);
		}
		Bounds lightBounds = lightSR.bounds;
		gridSize = lightBounds.size.x * gridSizeFactor;
		gridGap = gridSize * gridGapFactor;


	}

	public void DrawGrid(Player player){

		GameObject GridGO;
		// define the actual gameobject to be drawn
		if(player == Player.Player1){
			GridGO = Player1Light;
		} else if(player == Player.Player2){
			GridGO = Player2Light;
		} else{
			return;
		}

		Vector3 bottomleft = bounds.center - bounds.extents;
		Vector3 topright = bounds.center + bounds.extents;
		Vector3 bottomright = new Vector3 (topright.x, bottomleft.y, bottomleft.z);
		Vector3 topleft = new Vector3 (bottomleft.x, topright.y, bottomleft.z);


		// create the child grid objects


		float middleLeftX = bounds.center.x - gridGap / 2.0f;
		float middleRightX = bounds.center.x + gridGap / 2.0f;

		// create the left half of grid sys
		for(float xCursor = middleLeftX; xCursor >= bottomleft.x; xCursor -= gridGap){
			for(float yCursor = topleft.y; yCursor >= bottomright.y; yCursor -= gridGap){
				// instatiate a single grid and set this transform as its parent
				Vector3 newGridPos = new Vector3 (xCursor, yCursor, topleft.z);
				Quaternion newGridRot = transform.rotation;
				GameObject newGrid = (GameObject)Instantiate (GridGO, newGridPos, newGridRot);
				newGrid.transform.localScale = new Vector3 (gridSizeFactor, gridSizeFactor, gridSizeFactor);
				newGrid.transform.parent = transform;
			}
		}
		// create the right half of grid sys
		for(float xCursor = middleRightX; xCursor <= bottomright.x; xCursor += gridGap){
			for(float yCursor = topleft.y; yCursor >= bottomright.y; yCursor -= gridGap){
				// instatiate a single grid and set this transform as its parent
				Vector3 newGridPos = new Vector3 (xCursor, yCursor, topleft.z);
				Quaternion newGridRot = transform.rotation;
				GameObject newGrid = (GameObject)Instantiate (GridGO, newGridPos, newGridRot);
				newGrid.transform.localScale = new Vector3 (gridSizeFactor, gridSizeFactor, gridSizeFactor);
				newGrid.transform.parent = transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
