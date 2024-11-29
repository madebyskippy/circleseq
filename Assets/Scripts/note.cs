using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	[SerializeField] private AudioSource m_AudioSource;
	[SerializeField] private ScaleSpring m_ScaleSpring;

	public Slot Slot { get; set; }

	public void Play() {
		m_AudioSource.Stop();
		m_AudioSource.Play();
		Bounce();
	}

	public void Bounce() {
		m_ScaleSpring.Bounce();
	}
}
