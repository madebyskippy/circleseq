using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Flow : MonoBehaviour {

	[SerializeField] private NoteManager m_NoteManager;
	[SerializeField] private Player m_Player;
	[SerializeField] private Track[] m_Tracks;

	[Header("Options")]
	[SerializeField] private Transform m_Indicator;
	[SerializeField] private Option[] m_Options;

	[Header("UI")]
	[SerializeField] private GameObject m_UIHolder;
	[SerializeField] private Collider2D m_StartButton;

	private Camera Camera { get; set; }
	private int ChosenOptionIndex { get; set; }

	public void StartPlaying() {
		m_UIHolder.SetActive(false);
		m_Player.IsPlaying = true;
		m_NoteManager.Initialize(m_Options[this.ChosenOptionIndex].SoundPack);
		for (int i = 0; i < m_Tracks.Length; i++) {
			m_Tracks[i].Setup(m_Options[this.ChosenOptionIndex].TrackSlotCounts[i]);
		}
	}

	private void Start() {
		this.Camera = Camera.main;
		this.ChosenOptionIndex = Random.Range(0, m_Options.Length);
		IndicateOption();
	}

	private void Update() {
		//on choose option
		if (Input.GetMouseButtonUp(0)) {
			Vector3 mousePosition = this.Camera.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = m_StartButton.transform.position.z;
			if (m_StartButton.bounds.Contains(mousePosition)) {
				StartPlaying();
				return;
			}
			for (int i = 0; i < m_Options.Length; i++) {
				mousePosition.z = m_Options[i].Collider.transform.position.z;
				if (m_Options[i].Collider.bounds.Contains(mousePosition)) {
					this.ChosenOptionIndex = i;
					IndicateOption();
					break;
				}
			}
		}
	}

	private void IndicateOption() {
		m_Indicator.position = m_Options[this.ChosenOptionIndex].Collider.transform.position + Vector3.up;
	}
}

[System.Serializable]
public class Option {
	[SerializeField] private int[] m_TrackSlotCounts;
	[SerializeField] private SoundPack m_SoundPack;
	[SerializeField] private Collider2D m_Collider;

	public Collider2D Collider => m_Collider;
	public SoundPack SoundPack => m_SoundPack;
	public int[] TrackSlotCounts => m_TrackSlotCounts;
}
