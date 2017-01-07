using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TX;

[RequireComponent(typeof(Rigidbody2D), typeof(ConstantForce2D))]
public class Rocket_Control : BaseBehaviour {

	[Range(0.1f, 1f)]
	public float Handling;

	/// <summary>
	/// The max rotation.
	/// </summary>
	public const float MaxRotation = 6;

	/// <summary>
	/// Thrust force.
	/// </summary>
	[Range(1, 100)]
	public int Force;

	private Rigidbody2D Rigidbody;
	private ConstantForce2D Thrust;

	void Awake()
	{
		Rigidbody = GetComponent<Rigidbody2D>();
		Thrust = GetComponent<ConstantForce2D>();
	}

	// Update is called once per frame
	void Update () {
		float dir = Input.GetAxis("Horizontal");
		if (dir != 0)
		{
			transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -dir * MaxRotation * Handling);
		}
	}

	[InspectorButton("Turn On")]
	void TurnOn(){
		Thrust.relativeForce = new Vector2(0, Force);
	}

	[InspectorButton("Turn Off")]
	void TurnOff(){
		Thrust.relativeForce = Vector2.zero;
	}
}
