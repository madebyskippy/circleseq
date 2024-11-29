using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	[SerializeField] private AudioSource m_AudioSource;
	[SerializeField] private ScaleSpring m_ScaleSpring;

	[Space(10)]
	[SerializeField] private float m_OnDuration;
	[SerializeField] private GameObject m_On;
	[SerializeField] private GameObject m_Off;

	public Slot Slot { get; set; }

	private float OnStartTime { get; set; }

	public void Play() {
		m_AudioSource.Stop();
		m_AudioSource.Play();
		Bounce();
		this.OnStartTime = Time.time;
		m_Off.SetActive(false);
		m_On.SetActive(true);
	}

	public void Bounce() {
		m_ScaleSpring.Bounce();
	}

	private void Update() {
		if (m_On.activeSelf) {
			if (Time.time - this.OnStartTime > m_OnDuration) {
				m_On.SetActive(false);
				m_Off.SetActive(true);
			}
		}
	}
}
