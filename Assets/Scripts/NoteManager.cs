using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour {

	[SerializeField] private Note m_NotePrefab;
	[SerializeField] private float m_NoteTouchRadius = 0.5f;
	[SerializeField] private Transform m_NoteSpawnPosition;

	[Space(10)]
	[SerializeField] private float m_SlotPlacementThreshold;
	[SerializeField] private List<Track> m_Tracks;

	private Camera Camera { get; set; }
	private List<Note> Notes { get; set; }
	private Note GrabbedNote { get; set; }
	private Vector3 GrabOffset { get; set; }

	private void Start() {
		this.Notes = new List<Note>();
		this.Camera = Camera.main;
		SpawnNote();
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 position = this.Camera.ScreenToWorldPoint(Input.mousePosition);
			foreach (Note note in this.Notes) {
				position.z = note.transform.position.z;
				if (Vector3.Distance(position, note.transform.position) < m_NoteTouchRadius) {
					this.GrabbedNote = note;
					this.GrabOffset = note.transform.position - position;
					break;
				}
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			PlaceNote(this.GrabbedNote);
			this.GrabbedNote = null;
		}

		if (this.GrabbedNote != null) {
			Vector3 position = this.Camera.ScreenToWorldPoint(Input.mousePosition) + this.GrabOffset;
			Vector3 newPosition = Vector3.Lerp(this.GrabbedNote.transform.position, position, 0.5f);
			newPosition.z = this.GrabbedNote.transform.position.z;
			this.GrabbedNote.transform.position = newPosition;
		}
	}

	private void PlaceNote(Note note) {
		float closestSlotDistance = Mathf.Infinity;
		Track closestTrack = null;
		Slot closestSlot = null;
		Vector3 notePos = note.transform.position;
		foreach (Track track in m_Tracks) {
			foreach (Slot slot in track.Slots) {
				notePos.z = slot.Position.z;
				float distance = Vector3.Distance(notePos, slot.Position);
				if (distance < m_SlotPlacementThreshold && distance < closestSlotDistance) {
					closestSlotDistance = distance;
					closestSlot = slot;
					closestTrack = track;
				}
			}
		}
		if (closestSlot != null) {
			closestTrack.AddNote(note, closestSlot);
			SpawnNote();
		} else {
			note.transform.position = m_NoteSpawnPosition.position;
		}
	}

	private void SpawnNote() {
		this.Notes.Add(Instantiate(m_NotePrefab, this.transform));
		this.Notes[^1].transform.position = m_NoteSpawnPosition.position;
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		if (this.Notes != null) {
			foreach (Note note in this.Notes) {
				Gizmos.DrawWireSphere(note.transform.position, m_NoteTouchRadius);
			}
		}
	}
}
