﻿using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {

	[SerializeField]
	private	GameObject _player;

    [SerializeField]
    private CameraFollow _cam;

	private Player _pm;

	private bool _left;
	private bool _forward;
	private bool _right;
	private bool _backward;
    private bool _leftClick;

	// Use this for initialization
	void Start () {
		_left = _forward = _right = _backward = _leftClick = false;
		_pm = _player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

		keydownCheck ();
		keyupCheck ();
		_pm.Move (_left,_forward,_right,_backward);
        if (_leftClick) {
            _pm.Fire();
        }

	}

	void keydownCheck()
	{
		// W key for forward movement
		if(Input.GetKeyDown(KeyCode.W))
		{
			_forward = true;
			//Debug.Log("W is pressed");
		}
		
		// A key for left side movement
		if(Input.GetKeyDown(KeyCode.A))
		{
			_left = true;
			//Debug.Log("A is pressed");
		}
		
		// S key for backwards movement
		if(Input.GetKeyDown(KeyCode.S))
		{
			_backward = true;
			//Debug.Log("S is pressed");
		}
		
		// D key for right side movements
		if(Input.GetKeyDown(KeyCode.D))
		{
			_right = true;
			//Debug.Log("D is pressed");
		}

        if (Input.GetKeyDown(KeyCode.Space)) {
            _cam.shake(30);
        }

        // LMB for shooting
        if (Input.GetMouseButtonDown(0)) {
            _leftClick = true;
            //Debug.Log(LMB is pressed");

        }
        return;
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
        if (Input.GetMouseButtonUp(0)) {
            _leftClick = false;
            //Debug.Log("LMB is released");
        }
	}

}
