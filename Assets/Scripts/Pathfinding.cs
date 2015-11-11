using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {
	// * = Serialize field to remain private and editable in unity inspector.
	private List<GameObject> obstacles;

	// The target we need to move to (*).
	[SerializeField]
	private GameObject target;

	// Array for gameobjects at the start of the game.
	private GameObject[] GameobjectsAtStart;
	// Starting position of the AI that will follow the path.
	private Vector3 AIPosition;

	// Use this for initialization
	void Start () {
		// Initialize obstacles list.
		obstacles = new List<GameObject> ();
		// Fill array with objects that exist at the start of the game tagged with "Obstacle".
		GameobjectsAtStart = GameObject.FindGameObjectsWithTag ("obstacle");
		// Store all objects from array in a list for dynamic adding and removing later one.
		FillObjectList (GameobjectsAtStart);

	}
	
	// Update is called once per frame
	void Update () {



	}

	// method for filling the obstacles list with given array of gameobjects
	void FillObjectList(GameObject[] current)
	{
		foreach(GameObject temp in current)
		{
			obstacles.Add(temp);
		}
	}
}
