using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : TemporalSingleton<CharacterManager>
{
	[SerializeField] private List<CharacterComponent> m_characters = new List<CharacterComponent>(0);

	private int m_currentCharIndex = 0;

	public List<CharacterComponent> Characters { get => m_characters; set => m_characters = value; }

	public void SwitchChar(int index)
	{
		//Needs to be implemented and designed
	}

	public void DealStartOfTurnEffects()
	{
		for (int i = 0; i < m_characters.Count; i++)
		{
			if(i == m_currentCharIndex)
			{
				m_characters[i].StartOfTurnEffects(true);
			}
			else
			{
				m_characters[i].StartOfTurnEffects(false);
			}
		}
	}

	public void DealEndOfTurnEffects()
	{
		for (int i = 0; i < m_characters.Count; i++)
		{
			if (i == m_currentCharIndex)
			{
				m_characters[i].StartOfTurnEffects(true);
			}
			else
			{
				m_characters[i].StartOfTurnEffects(false);
			}
		}
	}
}
