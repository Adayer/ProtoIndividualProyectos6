using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : TemporalSingleton<CharacterManager>
{
	[SerializeField] private List<CharacterComponent> m_characters = new List<CharacterComponent>(0);

	[SerializeField] private Transform[] m_playerPositions = new Transform[0];

	private int m_currentCharIndex = 0;

	public List<CharacterComponent> Characters { get => m_characters; set => m_characters = value; }

	private void Start()
	{
		SwitchChar();
	}

	public void SwitchChar()
	{
		switch (HandManager.Instance.CurrentCharIndex)
		{
			case 0:
				{
					m_characters[0].transform.position = m_playerPositions[0].position;
					m_characters[1].transform.position = m_playerPositions[1].position;
					m_characters[2].transform.position = m_playerPositions[2].position;
				}
				break;
			case 1:
				{
					m_characters[0].transform.position = m_playerPositions[2].position;
					m_characters[1].transform.position = m_playerPositions[0].position;
					m_characters[2].transform.position = m_playerPositions[1].position;
				}
				break;
			case 2:
				{
					m_characters[0].transform.position = m_playerPositions[1].position;
					m_characters[1].transform.position = m_playerPositions[2].position;
					m_characters[2].transform.position = m_playerPositions[0].position;
				}
				break;
			default:
				break;
		}

		for (int i = 0; i < m_characters.Count; i++)
		{
			if(HandManager.Instance.CurrentCharIndex == i)
			{
				Color colorAux = m_characters[i].transform.GetComponent<SpriteRenderer>().color;

				m_characters[i].transform.GetComponent<SpriteRenderer>().color = new Color(colorAux.r, colorAux.g, colorAux.b, 1f);


				Image[] imgsAux = m_characters[i].transform.GetComponentsInChildren<Image>();

				for (int j = 0; j < imgsAux.Length; j++)
				{
					colorAux = imgsAux[j].color;
					imgsAux[j].color = new Color(colorAux.r, colorAux.g, colorAux.b, 1f);
				}
			}
			else
			{
				Color colorAux = m_characters[i].transform.GetComponent<SpriteRenderer>().color;

				m_characters[i].transform.GetComponent<SpriteRenderer>().color = new Color(colorAux.r, colorAux.g, colorAux.b, 0.5f);


				Image[] imgsAux = m_characters[i].transform.GetComponentsInChildren<Image>();

				for (int j = 0; j < imgsAux.Length; j++)
				{
					colorAux = imgsAux[j].color;
					imgsAux[j].color = new Color(colorAux.r, colorAux.g, colorAux.b, 0.5f);
				}
			}
		}
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
