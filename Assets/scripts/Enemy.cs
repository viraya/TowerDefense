using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private int _health = 5;
    private bool _alive = true;

    public int health {
        get {
            return _health;
        }
        set {
            if (value > 0) {
                _health = value;
            }
        }
    }

	void Update () {
        if (health <= 0) {
            _alive = false;
            _death();
        }
	}

    private void _death() {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Damage the enemy then returns a boolean in return to confirm his death.
    /// </summary>
    /// <param name="damage">The damage to deal to the enemy</param>
    /// <returns>Did this blow kill me, I return true else false.</returns>
    public bool damage(int damage) {
        _health -= damage;
        Debug.Log(this + " damaged for " + damage);

        //Kill confirm, setup for currency later.
        if (health <= 0) {
            return true;
        } else {
            return false;
        }
    }

	void FixedUpdate(){
		this.transform.position = Vector3.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(0,0), 1 * Time.deltaTime);
	}

}
