using UnityEngine;
using System.Collections.Generic;

public class Shield : MonoBehaviour {

    [SerializeField]
    private int _health = 100;
    [SerializeField]
    private bool _running = true;
    [SerializeField]
    private bool _turnedOn = true;
    [SerializeField]
    private List<GameObject> _attackers;
    [SerializeField]
    private Sprite[] _shieldStates = new Sprite[5];

    void Start() {
        InvokeRepeating("dmsHandling", 0, 1);
    }

    void FixedUpdate() {
        if (_running) {
            turnOn();

            if (_health >= 90) {
                this.GetComponent<SpriteRenderer>().sprite = _shieldStates[4];
            } else if (_health >= 75) {
                this.GetComponent<SpriteRenderer>().sprite = _shieldStates[3];
            } else if (_health >= 50) {
                this.GetComponent<SpriteRenderer>().sprite = _shieldStates[2];
            } else if (_health >= 25) {
                this.GetComponent<SpriteRenderer>().sprite = _shieldStates[1];
            } else if (_health >= 1) {
                this.GetComponent<SpriteRenderer>().sprite = _shieldStates[0];
            }
        }
    }

    private void turnOn() {
        if (!_turnedOn) {
            _turnedOn = true;
            InvokeRepeating("dmsHandling", 0, 1);
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void turnOff() {
        Debug.Log("Shield down");
        _turnedOn = false;
        CancelInvoke();
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void dmsHandling() {
        _health -= _attackers.Count;
        _attackers = new List<GameObject>();
        if (_health < 0 || !_running) {
            _health = 0;
            _running = false;
            turnOff();
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        string name = other.collider.name;
        if (name == "Enemy" || name == "Enemy(Clone)" && _running) {
            if (!_attackers.Contains(other.gameObject)) {
                _attackers.Add(other.gameObject);
            }
        }
    }

    /// <summary>
    /// Heal the shield, can't have it stay down of course.
    /// </summary>
    /// <param name="healFor">The amount to heal</param>
    public void Heal(int healFor) {
        _health += healFor;
        if (_health > 100) _health = 100;
        if (!_running) _running = true;
    }
}
