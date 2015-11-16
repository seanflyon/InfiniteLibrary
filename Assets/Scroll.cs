using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	public int width = 4;
	public int height = 4;

	public float damageSoFar = 0f;

	public GameObject exitRune;

	public GameObject slotPrefab;

	// Use this for initialization
	void Start () {
		for (int w = 0; w < width; w++) {
			for (int h = 0; h < height; h++) {
				GameObject slotObject = (GameObject) Instantiate(slotPrefab);
				slotObject.transform.parent = transform;
				slotObject.GetComponent<Slot>().init(this, w, h);
			}
		}
	}

	public VirtualRune getRune (int x, int y) {
		if (x >= 0 && x < width && y >= 0 && y < height) {
			int n = (y*width + x);
			Debug.Log("getRune x: " + x + " y: " + y + " -> " + n);
			Debug.Log(transform.GetChild(n));
			if (transform.GetChild(n).childCount > 0) {
				return transform.GetChild(n).GetChild(0).gameObject.GetComponent<Rune>();
			} else {
				return exitRune.GetComponent<NullRune>();
			}
		} else {
			return exitRune.GetComponent<NullRune>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {

			getRune (0,0).Activate();

		}
	}
}
