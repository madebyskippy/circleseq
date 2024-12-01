using System.Collections.Generic;
using UnityEngine;

public class SoundPack : MonoBehaviour {
	[SerializeField] private List<Sample> m_Samples;

	public List<Sample> Samples => m_Samples;
	public int NumSamples { get { return this.m_Samples.Count; } }
}