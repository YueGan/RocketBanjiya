using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TX;
using TX.Game;

public class HorizontalPatrol : BaseBehaviour {
	[Range(0, 10)]
	public float PatrolSpeed;

	[Range(1, 50)]
	public float PatrolRange;

	private SpriteRenderer sprite;
	private float patrolCenter;

	void Awake(){
		patrolCenter = transform.position.x + PatrolRange / 2;
		sprite = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		float deltaX = PatrolSpeed * Time.smoothDeltaTime;

		if (sprite.flipX) {
			position.x -= deltaX;
		} else {
			position.x += deltaX;
		}

		transform.position = position;

		// turn around
		if (position.x < patrolCenter - PatrolRange / 2)
			sprite.flipX = false;
		if (position.x > patrolCenter + PatrolRange / 2)
			sprite.flipX = true;
	}
}
