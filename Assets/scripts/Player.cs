using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private Rigidbody2D _rb;
    private Transform _tf;
    [SerializeField]
    private Transform _pointer;
    [SerializeField]
    private GameObject _bullet;
    private bool _ready;
    private float _timer;
    private float _cooldown = 0.05f;

    [SerializeField]
    private bool _facingLeft = true;
    public bool facingLeft {
        get { return _facingLeft; }
    }

    private bool _facingUp = true;
    public bool facingUp {
        get { return _facingUp; }
    }

    [SerializeField]
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
	}
	
	void Update () {
        if (_walking) {
            this.GetComponent<Animator>().enabled = true;
        } else {
            this.GetComponent<Animator>().enabled = false;
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
            GameObject bullet1 = Instantiate<GameObject>(_bullet);
            bullet1.GetComponent<Bullet>().owner = this.name;
            bullet1.transform.position = _pointer.position;
            bullet1.transform.position -= bullet1.transform.up/10;
            bullet1.transform.rotation = _pointer.rotation;
            StartCoroutine("SecondFire");
        }
    }

    IEnumerator SecondFire() {
        yield return new WaitForSeconds(0.05f);
        GameObject bullet2 = Instantiate<GameObject>(_bullet);
        bullet2.GetComponent<Bullet>().owner = this.name;
        bullet2.transform.position = _pointer.position;
        bullet2.transform.position += bullet2.transform.up / 10;
        bullet2.transform.rotation = _pointer.rotation;
    }

	public void Move(bool left , bool forward , bool right , bool backward)
	{
        if(left || right)
            _tf.localScale = new Vector3(Mathf.Abs(_tf.lossyScale.x), _tf.lossyScale.y, _tf.lossyScale.z);

        if (forward || backward)
            _tf.localScale = new Vector3(_tf.lossyScale.x, Mathf.Abs(_tf.lossyScale.y), _tf.lossyScale.z);

        /*if (forward) 
            _bx.offset = new Vector2(0.5f, 4.3f);
        else if(backward)
            _bx.offset = new Vector2(0.5f, -4);*/

		if (left) {
            _facingLeft = true;
			_rb.transform.Translate(Vector2.left * speed);
            _tf.localScale = new Vector3(_tf.lossyScale.x, _tf.lossyScale.y, _tf.lossyScale.z);
		}
		if(forward)
		{
            _facingUp = false;
			_rb.transform.Translate(Vector2.up * speed);
            //_tf.localScale = new Vector3(_tf.lossyScale.x,-_tf.lossyScale.y,_tf.lossyScale.z);
		}
		if(right)
		{
            _facingLeft = false;
			_rb.transform.Translate(Vector2.right * speed);
            _tf.localScale = new Vector3(-_tf.lossyScale.x, _tf.lossyScale.y, _tf.lossyScale.z);
		}
		if(backward)
		{
            _facingUp = true;
			_rb.transform.Translate(Vector2.down * speed);
            //_tf.localScale = new Vector3(_tf.lossyScale.x, _tf.lossyScale.y, _tf.lossyScale.z);
		}
	}

    void rotatePointer() {
        Vector3 _mousePos = Input.mousePosition;
        Vector3 _objectPos = Camera.main.WorldToScreenPoint(_pointer.position);
        _mousePos = _objectPos - _mousePos;
        float _angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
        _pointer.rotation = Quaternion.Lerp(_pointer.rotation, Quaternion.Euler(0, 0, _angle), 0.3f);
        return;
    }
}
