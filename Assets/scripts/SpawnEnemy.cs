using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject Enemy;
	bool waiting = false;

	[SerializeField]
	private int radius = 10;

	[SerializeField]
	private float timer = 1;
	
	float test = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!waiting)
		{
			SpawnEnemies (0.1f);
		}
	}

	Vector3 CalculatePosition(int radial)
	{
		int randomDeg = Random.Range (0,361);
		float xPos = Mathf.Cos (randomDeg) * radial;
		float yPos = Mathf.Tan (randomDeg) * xPos;

		return new Vector3 (xPos,yPos,0);
	}

	void SpawnEnemies(float Size)
	{
		test += 0.1f;
		GameObject instantiatedEnemy = Instantiate(Enemy, CalculatePosition(radius) , Quaternion.identity) as GameObject;
		instantiatedEnemy.transform.localScale = new Vector3(Size,Size,1);
		StartCoroutine("Waiting");
	}

	IEnumerator Waiting()
	{
		waiting = true;
		yield return new WaitForSeconds(timer);
		waiting = false;
	}

}
