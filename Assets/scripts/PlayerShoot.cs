using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private Transform _player;
    private Transform _target;
    private Vector3 _objectPos;
    private Vector3 _mousePos;
    private float _angle;

	void Start () {
        _target = this.GetComponent<Transform>();
	}
	
	void Update () {
        rotatePointer();
        _target.position = _player.position;
	}

    void rotatePointer() {
        _mousePos = Input.mousePosition;
        _objectPos = Camera.main.WorldToScreenPoint(_target.position);
        _mousePos = _objectPos - _mousePos;
        _angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0, 0, _angle),0.08f);
        return;
    }
}
