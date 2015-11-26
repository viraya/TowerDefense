using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// player is target to follow
	[SerializeField]
	private Transform _target;
    private Player _player;

	Camera mainCam;

	// Use this for initialization
	void Start () {
        mainCam = GetComponent<Camera>();
        _player = _target.gameObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        mainCam.orthographicSize = (Screen.height / 100F) / 2.2F;
        float addedX = 0;
        float addedY = 0;
        Vector3 tar = new Vector3(0, 0, 0);

		if(_target)
		{
            tar = _target.position;
            if (_player.facingLeft) {
                addedX = -1.5f;
            } else {
                addedX = 1.5f;
            }
            if (_player.facingUp) {
                addedY = -1.005f;
            } else {
                addedY = 1.005f;
            }
		}
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(tar.x + addedX, tar.y + addedY, -20), 0.03f);
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
