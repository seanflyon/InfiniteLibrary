using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public int n;
	public GameObject slotPrefab;
	public GameObject runePrefab;

	// Use this for initialization
	void Start () {
		for (int w = 0; w < n; w++) {
			GameObject slotObject = (GameObject) Instantiate(slotPrefab);
			slotObject.transform.parent = transform;
			GameObject runeObject = (GameObject) Instantiate(runePrefab);
			runeObject.GetComponent<Rune>().init();
			runeObject.GetComponent<Image>().color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
			runeObject.transform.parent = slotObject.transform;

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
