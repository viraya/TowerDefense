using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	void FixedUpdate(){
		this.transform.position = Vector3.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(0,0), 1 * Time.deltaTime);
	}

}
