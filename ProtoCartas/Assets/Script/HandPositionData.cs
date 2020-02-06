using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandPositionData
{
	[SerializeField] private Transform m_handPosition = null;
	private bool m_isBeingUsed = false;
	private Transform m_card = null;

	public Transform HandPosition { get => m_handPosition; set => m_handPosition = value; }
	public bool IsBeingUsed { get => m_isBeingUsed; set => m_isBeingUsed = value; }
	public Transform Card { get => m_card; set => m_card = value; }
}
