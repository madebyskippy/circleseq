using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

	private List<Note> Notes {
		get; set;
	}

	private void Start() {
		this.Notes = new List<Note>();
	}

	public void Play(float progress) {

	}

	public void AddNote(Note note) {
		this.Notes.Add(note);
	}

	public void RemoveNote(Note note) {
		this.Notes.Remove(note);
	}

}
