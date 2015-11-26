using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private Transform _tf;

    [SerializeField]
    private string _owner;
    public string owner {
        get { return _owner; }
        set { _owner = value; }
    }

    [SerializeField]
    private float _lifeTime = 10;

    [SerializeField]
    private int _damage = 1;
    public int damage {
        get { return _damage; }
        set { _damage = value; }
    }

    void Start() {
        _tf = this.GetComponent<Transform>();
        InvokeRepeating("Movement", 0, 0.01f);
    }

    void Movement() {
        _lifeTime -= 0.05f;
        if (_lifeTime <= 0) {
            CancelInvoke();
            Destroy(this.gameObject);
        }
        _tf.position += -this.transform.right/10;
    }

	void OnTriggerEnter2D (Collider2D other) {
        CharacterHealth health = other.GetComponent<CharacterHealth>();
        if (health != null && other.name != _owner) {
            health.damage(_damage, _owner);
            Destroy(this.gameObject);
        }
	}
}
