using UnityEngine;
using System.Collections;

public class Rune : VirtualRune {

	public Board board;

	public float damage;

	public int x;
	public int y;

	public char symbol;

	public float northProb;
	public float southProb;
	public float eastProb;
	public float westProb;

	public float waitTime = 0.2f;
	private float timeUntilNextRune = 0f;

	private VirtualRune nextRune = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (null != nextRune) {

			timeUntilNextRune -= Time.deltaTime;
			if (timeUntilNextRune <= 0) {
				transform.GetChild (0).gameObject.SetActive(false);
				nextRune.Activate ();
				nextRune = null;
			}
		}
	}

	public void init (Board board, int x, int y) {
		this.board = board;
		this.x = x;
		this.y = y;
		damage = Random.Range (0f, 100f);

		westProb = Random.Range (0f, 1f);

		southProb = Random.Range (0f, 1f);

		northProb = Random.Range (0f, 1f);

		eastProb = Random.Range (0f, 1f);

		float exitProb = Random.Range (0f, 0.5f);

		float sum = northProb + southProb + eastProb + westProb + exitProb;

		northProb = northProb / sum;
		southProb = northProb + southProb / sum;
		eastProb = southProb + eastProb / sum;
		westProb = eastProb + westProb / sum;
	}

	public void init (Board board, int x, int y, Board.RuneDescriptor desc) {
		this.board = board;
		this.x = x;
		this.y = y;
		damage = desc.damage;

		symbol = desc.symbol;
		
		northProb = desc.northProb;
		southProb = northProb + desc.southProb;
		eastProb = southProb + desc.eastProb;
		westProb = eastProb + desc.westProb;
	}

	private void setNextRune(VirtualRune rune) {
		nextRune = rune;
		Debug.DrawLine (transform.position, nextRune.transform.position, Color.green, waitTime);
		timeUntilNextRune = waitTime;
		transform.GetChild (0).gameObject.SetActive(true);
	}

	override public void Activate () {
		Debug.Log ("Rune " + x.ToString() + ", " + y.ToString() + " Deal " + damage.ToString() + " damage");
		board.damageSoFar += damage;
		float roll = Random.Range (0f, 1f);
		if (roll < northProb) {
			setNextRune (board.getRune (x, y + 1));
		} else if (roll < southProb) {
			setNextRune (board.getRune (x, y - 1));
		} else if (roll < eastProb) {
			setNextRune (board.getRune (x - 1, y));
		} else if (roll <  westProb) {
			setNextRune (board.getRune (x + 1, y));
		} else {
			Debug.Log("Exit");
			setNextRune(board.getRune (-1, -1));
		}
	}

	void OnMouseUp() {
		Activate ();
	}
}
