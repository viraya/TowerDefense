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
            Vector3 tar = target.position;
            transform.position = Vector3.Lerp(this.transform.position, new Vector3(tar.x, tar.y, -20), 0.08F);
		}

	}
}
