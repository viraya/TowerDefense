using UnityEngine;
using System.Collections.Generic;

public class Shield : MonoBehaviour {

    [SerializeField]
    private int _health = 100;
    [SerializeField]
    private bool _running = true;
    [SerializeField]
    private List<GameObject> _attackers;

    void Start() {
        InvokeRepeating("dmsHandling", 0, 1);
    }

    void FixedUpdate() {
        if (_running) {
            _health = 100;
            _running = true;
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            InvokeRepeating("dmsHandling", 0, 1);
        }
    }

    private void turnOff() {
        Debug.Log("Shield down");
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
