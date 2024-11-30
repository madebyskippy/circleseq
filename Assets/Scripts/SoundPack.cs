using System.Collections.Generic;
using UnityEngine;

public class SoundPack : MonoBehaviour {
	[SerializeField] private List<Sample> m_Samples;

	public List<Sample> Samples => m_Samples;
	public int NumSamples { get { return this.m_Samples.Count; } }
}

[System.Serializable]
public class Sample {
	[SerializeField] private AudioClip m_AudioClip;
	[Tooltip("optional")][SerializeField] private AudioClip[] m_AdditionalClipOptions;
	[SerializeField] private int[] m_SemitoneOptions;

	public AudioClip AudioClipToPlay {
		get {
			if (m_AdditionalClipOptions.Length > 0) {
				int randomIndex = Random.Range(-1, m_AdditionalClipOptions.Length);
				if (randomIndex > -1) {
					return m_AdditionalClipOptions[randomIndex];
				}
			}
			return m_AudioClip;
		}
	}

	public float Pitch {
		get {
			if (m_SemitoneOptions.Length > 0) {
				int semitones = m_SemitoneOptions[Random.Range(0, m_SemitoneOptions.Length)];
				return Mathf.Pow(1.059463f, semitones);
			}
			return 1;
		}
	}
}
