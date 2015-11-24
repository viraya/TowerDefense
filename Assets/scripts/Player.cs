using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private Rigidbody2D _rb;
    private Transform _tf;
    private BoxCollider2D _bx;
    [SerializeField]
    private Transform _pointer;
    [SerializeField]
    private GameObject _bullet;
    private bool _ready;
    private float _timer;
    private float _cooldown = 0.05f;

    private bool _walking = false;
    public bool walking {
        get { return _walking; }
        set { _walking = value;  }
    }

    private int _health;
    public int health {
        get { return _health;  }
        set { if (value <= 0) { _health = 1; } else { _health = value; } }
    }

	float speed = 0.02F;

	void Start () {
        _ready = true;
        _timer = 0;
		_rb = this.GetComponent<Rigidbody2D>();
        _tf = this.GetComponent<Transform>();
        _bx = this.GetComponent<BoxCollider2D>();
	}
	
	void Update () {
        if (_walking) {
            //walk animation
        } else {
            //idle animation
        }
        if (!_ready) {
            _timer += _cooldown;
        }
        if (_timer >= 1) {
            _ready = true;
            _timer = 0;
        }
        rotatePointer();
        _pointer.position = _tf.position;
	}

    private void _death() {
        Destroy(this.gameObject);
    }

    public void Fire() {
        if (_ready) {
            _ready = false;
            GameObject bullet = Instantiate<GameObject>(_bullet);
            bullet.GetComponent<Bullet>().owner = this.name;
            bullet.transform.position = _pointer.position;
            bullet.transform.rotation = _pointer.rotation;
        }
    }

	public void Move(bool left , bool forward , bool right , bool backward)
	{
        if(left || right)
            _tf.localScale = new Vector3(Mathf.Abs(_tf.lossyScale.x), _tf.lossyScale.y, _tf.lossyScale.z);

        if (forward || backward)
            _tf.localScale = new Vector3(_tf.lossyScale.x, Mathf.Abs(_tf.lossyScale.y), _tf.lossyScale.z);

        if (forward) 
            _bx.offset = new Vector2(0.5f, 4.3f);
        else if(backward)
            _bx.offset = new Vector2(0.5f, -4);

		if (left) {
			_rb.transform.Translate(Vector2.left * speed);
            _tf.localScale = new Vector3(_tf.lossyScale.x, _tf.lossyScale.y, _tf.lossyScale.z);
		}
		if(forward)
		{
			_rb.transform.Translate(Vector2.up * speed);
            _tf.localScale = new Vector3(_tf.lossyScale.x,-_tf.lossyScale.y,_tf.lossyScale.z);
		}
		if(right)
		{
			_rb.transform.Translate(Vector2.right * speed);
            _tf.localScale = new Vector3(-_tf.lossyScale.x, _tf.lossyScale.y, _tf.lossyScale.z);
		}
		if(backward)
		{
			_rb.transform.Translate(Vector2.down * speed);
            _tf.localScale = new Vector3(_tf.lossyScale.x, _tf.lossyScale.y, _tf.lossyScale.z);
		}
	}

    void rotatePointer() {
        Vector3 _mousePos = Input.mousePosition;
        Vector3 _objectPos = Camera.main.WorldToScreenPoint(_pointer.position);
        _mousePos = _objectPos - _mousePos;
        float _angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
        _pointer.rotation = Quaternion.Lerp(_pointer.rotation, Quaternion.Euler(0, 0, _angle), 0.08f);
        return;
    }
}
