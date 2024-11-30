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
	private Sample Sample { get; set; }

	public void SetSample(Sample sample) {
		this.Sample = sample;
	}

	public void Play() {
		m_AudioSource.clip = this.Sample.AudioClipToPlay;
		m_AudioSource.pitch = this.Sample.Pitch;
		m_OnDuration = m_AudioSource.clip.length;
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
