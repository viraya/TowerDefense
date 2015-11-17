using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// player is target to follow
	[SerializeField]
	private Transform target;

	Camera mainCam;

	// Use this for initialization
	void Start () {

		mainCam = GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		mainCam.orthographicSize = (Screen.height / 100F) / 2F;

		if(target)
		{
			transform.position = Vector3.Lerp(this.transform.position,target.position,0.08F) + new Vector3(0,0,-10);
		}

	}
}
