using UnityEngine;

[CreateAssetMenu(fileName = "Sample", menuName = "ScriptableObjects/Sample", order = 1)]
public class Sample : ScriptableObject {
	[SerializeField] private Note m_NotePrefab;
	[SerializeField] private AudioClip m_AudioClip;
	[Tooltip("optional")][SerializeField] private AudioClip[] m_AdditionalClipOptions;
	[SerializeField] private int[] m_SemitoneOptions;

	public Note NotePrefab => m_NotePrefab;

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
