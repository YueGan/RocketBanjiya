using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using TX;

[RequireComponent(typeof(Rigidbody2D), typeof(ConstantForce2D))]
public class RocketControl : BaseBehaviour {


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

	public ParticleSystem Exhaust;
	public ParticleSystem Flame;

	public GameObject Explosion;

	public UnityEvent LaunchEvent;
	private bool launched = false;

	public bool EngineOn {
		get{return _engineOn;}
		set{
			if (_engineOn != value) {
				_engineOn = value;

				if (value) {
					if (!launched) {
						launched = true;
						LaunchEvent.Invoke();
					}

					Thrust.relativeForce = new Vector2(0, Force);
					Exhaust.Play();
					Flame.Play();
				} else {
					Thrust.relativeForce = Vector2.zero;
					Exhaust.Stop();
					Flame.Stop();
				}
			}
		}
	}
	private bool _engineOn;
	private ConstantForce2D Thrust;

	void Awake()
	{
		Thrust = GetComponent<ConstantForce2D>();
	}

	// Update is called once per frame
	void Update () {
		float dir = Input.GetAxis("Horizontal");
		if (dir != 0)
		{
			transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -dir * MaxRotation * Handling);
		}

		EngineOn = Input.GetAxis("Vertical") == 1;
	}

	[InspectorButton("Teleport to Valley")]
	void TeleportToValley(){
		Vector3 pos = transform.position;
		pos.y = 2400;
		transform.position = pos;
	}
}
