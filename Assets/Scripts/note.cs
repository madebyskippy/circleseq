using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	[SerializeField] private AudioSource m_AudioSource;

	public void Play() {
		m_AudioSource.Stop();
		m_AudioSource.Play();
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
}
