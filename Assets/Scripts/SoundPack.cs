using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPack : MonoBehaviour {
	[SerializeField] private List<AudioClip> m_Clips;

	public List<AudioClip> Clips => m_Clips;
	public int NumClips { get { return this.Clips.Count; } }
}
