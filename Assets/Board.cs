using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
	public int width;
	public int height;
	public GameObject Globals;
	public GameObject runePrefab;
	public GameObject exitRune;

	public Rune[,] runes;

	public float damageSoFar = 0f;

	public struct RuneDescriptor {
		public float northProb;
		public float southProb;
		public float eastProb;
		public float westProb;
		public float damage;
		public char symbol;

		public RuneDescriptor(float northProb, float southProb, float eastProb, float westProb, float damage, char symbol) {
			this.northProb = northProb;
			this.southProb = southProb;
			this.eastProb = eastProb;
			this.westProb = westProb;
			this.damage = damage;
			this.symbol = symbol;
		}
	}

	public RuneDescriptor D = new RuneDescriptor(0.2f,0.2f,0.2f,0.2f,50f,'D');
	public RuneDescriptor N = new RuneDescriptor(0.8f,0.05f,0.05f,0.05f,0f,'N');
	public RuneDescriptor S = new RuneDescriptor(0.05f,0.8f,0.05f,0.05f,0f,'S');
	public RuneDescriptor E = new RuneDescriptor(0.05f,0.05f,0.8f,0.05f,0f,'E');
	public RuneDescriptor W = new RuneDescriptor(0.05f,0.05f,0.05f,0.8f,0f,'W');

	private int count = 0;

	// Use this for initialization
	void Start () {

		runes = new Rune[4, 4] { 
			{ r (S), r (S), r (S), r (S) },
			{ r (W), r (D), r (D), r (E) },
			{ r (W), r (D), r (D), r (E) },
			{ r (N), r (N), r (N), r (N) } 
		};
		//runes = new Rune[width, height];
		//for (int w = 0; w < width; w++) {
		//	for (int h = 0; h < height; h++) {
		//		GameObject runeObject = (GameObject) Instantiate(runePrefab, new Vector3(w, h, 0), Quaternion.identity);
		//		runes[w,h] = runeObject.GetComponent<Rune>();
		//		runes[w,h].init(this, w, h);
		//	}
		//}

		getRune (width/2, height/2).Activate ();
	}

	private Rune r(RuneDescriptor desc) {
		int y = count % width;
		int x = count / width;
		GameObject runeObject = (GameObject)Instantiate (runePrefab, new Vector3 (x, y, 0), Quaternion.identity);
		Rune rune = runeObject.GetComponent<Rune> ();
		//rune.init (this, x, y, desc);
		count++;
		return rune;
	}

	public VirtualRune getRune (int x, int y) {
		if (x >= 0 && x < width && y >= 0 && y < height) {
			return runes [x, y];
		} else {
			return exitRune.GetComponent<NullRune>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
