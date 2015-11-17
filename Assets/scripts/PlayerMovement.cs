using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private Rigidbody2D _rb;
	float speed = 0.02F;

	// Use this for initialization
	void Start () {
		_rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(bool left , bool forward , bool right , bool backward)
	{
		if (left) {
			_rb.transform.Translate(Vector2.left * speed);
		}
		if(forward)
		{
			_rb.transform.Translate(Vector2.up * speed);
		}
		if(right)
		{
			_rb.transform.Translate(Vector2.right * speed);
		}
		if(backward)
		{
			_rb.transform.Translate(Vector2.down * speed);
		}
	}

}
