using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	[SerializeField] private GameObject m_Dot;

	public Vector3 Position { get { return m_Dot.transform.position; } }
	public Track Track { get; set; }

	public void SetRadius(float radius) {
		m_Dot.transform.localPosition = new Vector3(radius, 0, 0);
	}

	public void Rotate(float angle) {
		this.transform.Rotate(new Vector3(0, 0, angle));
	}
}
