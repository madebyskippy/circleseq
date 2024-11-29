using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSpring : MonoBehaviour {

	[SerializeField] private float m_BounceForce;
	[SerializeField] private float m_Stiffness;
	[SerializeField] private float m_Damping;

	public void Bounce() {
		this.Velocity = m_BounceForce;
	}

	private float Velocity { get; set; }
	private float Scale { get; set; }

	private void Start() {
		this.Scale = this.transform.localScale.x;
	}

	private void Update() {
		this.Velocity += (-m_Stiffness * (this.Scale - 1)) - (m_Damping * this.Velocity);
		this.Scale += this.Velocity;
		this.transform.localScale = new Vector3(this.Scale, this.Scale, 1f);
	}
}
