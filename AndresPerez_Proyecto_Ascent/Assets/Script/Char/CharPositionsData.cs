using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharPositionsData
{
	[SerializeField] private Transform m_charTransform = null;
	[SerializeField] private CharacterComponent m_character = null;

	public Transform CharTransform { get => m_charTransform; set => m_charTransform = value; }
	public CharacterComponent Character { get => m_character; set => m_character = value; }
}
