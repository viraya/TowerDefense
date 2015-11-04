using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float maxSpeed = 1f;

    private Transform _tf;
    private float _xVel = 0;
    private float _yVel = 0;

	void Start () {
        _tf = this.GetComponent<Transform>();
        Vector3 posBack = _tf.position;
        maxSpeed *= 0.03f;
        _tf.position = utils.cP(_tf.position);
	}
	
	void Update () {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        _xVel = maxSpeed * hor;
        _yVel = maxSpeed * ver; 

        if (_xVel > maxSpeed) {
            _xVel = maxSpeed;
        }
        if (_yVel > maxSpeed) {
            _yVel = maxSpeed;
        }

        Vector3 addToPos = new Vector3(_xVel, _yVel, _yVel);

        print(addToPos);

        _tf.Translate(addToPos);
	}
}
