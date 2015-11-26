using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// player is target to follow
	[SerializeField]
	private Transform _target;

	Camera mainCam;

	// Use this for initialization
	void Start () {

        mainCam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	
		mainCam.orthographicSize = (Screen.height / 100F) / 1.2F;

		if(_target)
		{
            Vector3 tar = _target.position;
            transform.position = Vector3.Lerp(this.transform.position, new Vector3(tar.x, tar.y, -20), 0.08F);
		}

	}

    /// <summary>
    /// Shake the camera on the X axis.
    /// </summary>
    /// <param name="intensity">How hard do you want it to be.</param>
    public void shake(int intensity) {

        float shaked = intensity / 28;
        float times = intensity / 2;

        transform.position += new Vector3(shaked, 0, 0);
        StartCoroutine(shakePart2(shaked,times));
    }

    IEnumerator shakePart2(float intensity, float times) {
        yield return new WaitForSeconds(0.02f);
        transform.position -= new Vector3(intensity, 0, 0);
        if(times > 0)
            StartCoroutine(shakePart2(intensity/2, times-1));
    }
}
