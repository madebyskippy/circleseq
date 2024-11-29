
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private Transform m_Playhead;
	[SerializeField] private List<Track> m_Tracks;

	[Space(10)]

	[Min(0.1f)]
	[SerializeField] private float m_LoopDuration;

	private float Progress { get; set; }

	private void Start() {
		this.Progress = 0;
	}

	private void Update() {
		this.Progress = Mathf.Repeat(this.Progress + Time.deltaTime / m_LoopDuration, 1f);
		m_Playhead.rotation = Quaternion.Euler(0, 0, this.Progress * 360f);
		foreach (Track track in m_Tracks) {
			track.Play(this.Progress);
		}
	}
}
