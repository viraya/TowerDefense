using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private Rigidbody2D _rb;
    private Transform _tf;
    private BoxCollider2D _bx;

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

	// Use this for initialization
	void Start () {
		_rb = this.GetComponent<Rigidbody2D>();
        _tf = this.GetComponent<Transform>();
        _bx = this.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_walking) {
            //walk animation
        } else {
            //idle animation
        }
	}

    private void _death() {
        Destroy(this.gameObject);
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

}
