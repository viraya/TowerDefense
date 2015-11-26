using UnityEngine;
using System.Collections;

public class PartsSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject Part;
    bool waiting = false;

    [SerializeField]
    private int radius = 10;

    [SerializeField]
    private float timer = 1;

    [SerializeField]
    private Shield shield;

    float test = 0;

    void Start() {

    }

    void Update() {
        if (!waiting) {
            SpawnEnemies(0.1f);
        }
    }

    Vector3 CalculatePosition(int radial) {
        int randomDeg = Random.Range(0, 361);
        float xPos = Mathf.Cos(randomDeg) * radial;
        float yPos = Mathf.Tan(randomDeg) * xPos;

        return new Vector3(xPos, yPos, 0);
    }

    void SpawnEnemies(float Size) {
        test += 0.1f;
        GameObject instantiatedPart = Instantiate(Part, CalculatePosition(radius), Quaternion.identity) as GameObject;
        instantiatedPart.GetComponent<Part>().shield = shield;
        StartCoroutine("Waiting");
    }

    IEnumerator Waiting() {
        waiting = true;
        yield return new WaitForSeconds(timer);
        waiting = false;
    }
}
