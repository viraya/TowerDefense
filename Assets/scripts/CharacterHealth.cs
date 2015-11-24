using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

    [SerializeField]
    private int _health = 5;
    [SerializeField]
    private bool _alive = true;

    private string _killer;

    public int health {
        get { return _health; }
        set { if (value > 0) { _health = value; } }
    }

    public bool alive {
        get { return _alive; }
    }

    void Update() {
        if (health <= 0) {
            _alive = false;
        }

        if (!_alive) {
            _death();
        }
    }

    private void _death() {
        if (_killer != "")
            Debug.Log(this.name + " was killed by " + _killer);
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Damage the enemy then returns a boolean in return to confirm his death.
    /// </summary>
    /// <param name="damage">The damage to deal to the enemy</param>
    /// <param name="attacker">Who attacked me?</param>
    /// <returns>Did this blow kill me, I return true else false.</returns>
    public bool damage(int damage, string attacker = null) {
        _health -= damage;
        //Debug.Log(this + " damaged for " + damage);

        //Kill confirm, setup for currency later.
        if (health <= 0) {
            if (attacker != null) { _killer = attacker; }
            return true;
        } else {
            return false;
        }
    }
}
