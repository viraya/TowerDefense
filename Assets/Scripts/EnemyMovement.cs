using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		this.transform.position = Vector3.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(0,0), 1 * Time.deltaTime);
	}

}
