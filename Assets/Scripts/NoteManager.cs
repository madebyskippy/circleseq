using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour {

	[SerializeField] private Note m_NotePrefab;
	[SerializeField] private float m_NoteTouchRadius = 0.5f;

	private Camera Camera { get; set; }
	private List<Note> Notes { get; set; }
	private Note GrabbedNote { get; set; }
	private Vector3 GrabOffset { get; set; }

	private void Start() {
		this.Notes = new List<Note>();
		this.Camera = Camera.main;
		this.Notes.Add(Instantiate(m_NotePrefab, this.transform));
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
			this.GrabbedNote = null;
		}

		if (this.GrabbedNote != null) {
			Vector3 position = this.Camera.ScreenToWorldPoint(Input.mousePosition) + this.GrabOffset;
			Vector3 newPosition = Vector3.Lerp(this.GrabbedNote.transform.position, position, 0.5f);
			newPosition.z = this.GrabbedNote.transform.position.z;
			this.GrabbedNote.transform.position = newPosition;
		}
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