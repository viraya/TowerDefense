using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {

	[SerializeField]
	private	GameObject Player;

	private PlayerMovement _pm;

	private bool left;
	private bool forward;
	private bool right;
	private bool backward;

	// Use this for initialization
	void Start () {
		left = forward = right = backward = false;
		_pm = Player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

		keydownCheck ();
		keyupCheck ();
		_pm.Move (left,forward,right,backward);

	}

	void keydownCheck()
	{
		// W key for forward movement
		if(Input.GetKeyDown(KeyCode.W))
		{
			forward = true;
			//Debug.Log("W is pressed");
		}
		
		// A key for left side movement
		if(Input.GetKeyDown(KeyCode.A))
		{
			left = true;
			//Debug.Log("A is pressed");
		}
		
		// S key for backwards movement
		if(Input.GetKeyDown(KeyCode.S))
		{
			backward = true;
			//Debug.Log("S is pressed");
		}
		
		// D key for right side movements
		if(Input.GetKeyDown(KeyCode.D))
		{
			right = true;
			//Debug.Log("D is pressed");
		}
	}

	void keyupCheck()
	{
		// W key for forward movement
		if(Input.GetKeyUp(KeyCode.W))
		{
			forward = false;
			//Debug.Log("W is released");
		}
		
		// A key for left side movement
		if(Input.GetKeyUp(KeyCode.A))
		{
			left = false;
			//Debug.Log("A is released");
		}
		
		// S key for backwards movement
		if(Input.GetKeyUp(KeyCode.S))
		{
			backward = false;
			//Debug.Log("S is released");
		}
		
		// D key for right side movements
		if(Input.GetKeyUp(KeyCode.D))
		{
			right = false;
			//Debug.Log("D is released");
		}
	}

}
