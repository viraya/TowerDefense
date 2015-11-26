using UnityEngine;
using System.Collections.Generic;

public class MainCore : MonoBehaviour {

    [SerializeField]
    private int _health = 1000;
    [SerializeField]
    private bool _alive = true;
    [SerializeField]
    private List<GameObject> _attackers;
    [SerializeField]
    private Sprite _destroyedState;
    [SerializeField]
    private Sprite _workingState;

    //private GameObject body;

    void Start() {
        //body = gameObject;
        InvokeRepeating("dmsHandling", 0, 1);
        _workingState = this.GetComponent<SpriteRenderer>().sprite;
    }

    void FixedUpdate() {
        if (_alive) {
            GetComponent<SpriteRenderer>().sprite = _workingState;
            InvokeRepeating("dmsHandling", 0, 1);
        }
    }

    private void destroyed() {
        Debug.Log("Main core destroyed");
        CancelInvoke();
        GetComponent<SpriteRenderer>().sprite = _destroyedState;
        //GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void dmsHandling() {
        _health -= _attackers.Count;
        _attackers = new List<GameObject>();
        if (_health < 0 || !_alive) {
            _health = 0;
            _alive = false;
            destroyed();
        }
    }

	private void OnCollisionStay2D(Collision2D other) {
        string name = other.collider.name;
        if (name == "Enemy" || name == "Enemy(Clone)" && _alive) {
            if(!_attackers.Contains(other.gameObject)) {
                _attackers.Add(other.gameObject);
            }
        }
    }
}
