using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

	[SerializeField] private float m_Radius;
	[SerializeField] private int m_NumSlots;
	[SerializeField] private Slot m_SlotPrefab;

	public List<Slot> Slots { get; private set; }

	private List<Note> Notes { get; set; }

	private int LastSlotIndex { get; set; }

	private void Start() {
		this.Notes = new List<Note>();
		this.Slots = new List<Slot>();
		for (int i = 0; i < m_NumSlots; i++) {
			Slot newSlot = Instantiate(m_SlotPrefab, this.transform);
			newSlot.SetRadius(m_Radius);
			newSlot.Rotate((360f / m_NumSlots) * i);
			newSlot.Track = this;
			newSlot.Note = null;
			this.Slots.Add(newSlot);
		}
		this.LastSlotIndex = 0;
	}

	public void Play(float progress) {
		int slot = Mathf.FloorToInt(progress * m_NumSlots);
		if (slot != this.LastSlotIndex) {
			this.LastSlotIndex = slot;
			if (this.Slots[slot].Note != null) {
				this.Slots[slot].Note.Play();
			}
		}
	}

	public void AddNote(Note note, Slot slot) {
		if (this.Slots.Contains(slot)) {
			Vector3 position = slot.Position;
			position.z = note.transform.position.z;
			note.transform.position = position;
			note.Slot = slot;
			note.Bounce();
			this.Notes.Add(note);
			slot.Note = note;
		}
	}

	public void RemoveNote(Note note) {
		note.Slot.Note = null;
		this.Notes.Remove(note);
	}

}
