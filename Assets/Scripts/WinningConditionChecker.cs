using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TX;
using TX.Game;

public class WinningConditionChecker : BaseBehaviour {

	private RocketControl rocket;

	void Awake(){
		rocket = GameObject.FindWithTag ("Player").GetComponent<RocketControl>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform == GameManager.Instance.ScoreRegion) {
			Debug.Log ("You Won");
			GameManager.Instance.GameOver (true);
			gameObject.SetActive (false);

		} else if (other.transform == GameManager.Instance.FailRegion) {
			Debug.Log ("You Lose");

			rocket.EngineOn = false;
			rocket.enabled = false;
			rocket.GetComponent<Rigidbody2D> ().simulated = false;
			rocket.transform.SetParent (other.transform);

			GameManager.Instance.GameOver (false);
			gameObject.SetActive (false);
		}
	}
}
