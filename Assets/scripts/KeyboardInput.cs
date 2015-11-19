using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {

	[SerializeField]
	private	GameObject _player;

	private PlayerMovement _pm;

	private bool _left;
	private bool _forward;
	private bool _right;
	private bool _backward;

    private bool _keyDown = false;

	// Use this for initialization
	void Start () {
		_left = _forward = _right = _backward = false;
		_pm = _player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

		_keyDown = keydownCheck ();
		keyupCheck ();
		_pm.Move (_left,_forward,_right,_backward);

	}

	bool keydownCheck()
	{
        bool keyDown = false;
		// W key for forward movement
		if(Input.GetKeyDown(KeyCode.W))
		{
            keyDown = true;
			_forward = true;
			//Debug.Log("W is pressed");
		}
		
		// A key for left side movement
		if(Input.GetKeyDown(KeyCode.A))
		{
            keyDown = true;
			_left = true;
			//Debug.Log("A is pressed");
		}
		
		// S key for backwards movement
		if(Input.GetKeyDown(KeyCode.S))
		{
            keyDown = true;
			_backward = true;
			//Debug.Log("S is pressed");
		}
		
		// D key for right side movements
		if(Input.GetKeyDown(KeyCode.D))
		{
            keyDown = true;
			_right = true;
			//Debug.Log("D is pressed");
		}
        return keyDown;
	}

	void keyupCheck()
	{
		// W key for forward movement
		if(Input.GetKeyUp(KeyCode.W))
		{
			_forward = false;
			//Debug.Log("W is released");
		}
		
		// A key for left side movement
		if(Input.GetKeyUp(KeyCode.A))
		{
			_left = false;
			//Debug.Log("A is released");
		}
		
		// S key for backwards movement
		if(Input.GetKeyUp(KeyCode.S))
		{
			_backward = false;
			//Debug.Log("S is released");
		}
		
		// D key for right side movements
		if(Input.GetKeyUp(KeyCode.D))
		{
			_right = false;
			//Debug.Log("D is released");
		}
	}

}
