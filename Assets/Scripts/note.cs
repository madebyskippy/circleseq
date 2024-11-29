using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	[SerializeField] private AudioSource m_AudioSource;

	public void Play() {
		m_AudioSource.Stop();
		m_AudioSource.Play();
	}
}
