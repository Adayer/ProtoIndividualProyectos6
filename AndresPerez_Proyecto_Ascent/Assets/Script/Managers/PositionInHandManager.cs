﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInHandManager : TemporalSingleton<PositionInHandManager>
{
	[SerializeField] private HandPositionData[] m_handPositions = new HandPositionData[0];
	
	public void PlaceCardInHand(Transform cardToHand)
	{
		for (int i = 0; i < m_handPositions.Length; i++)
		{
			
			if (!m_handPositions[i].IsBeingUsed)
			{
				m_handPositions[i].IsBeingUsed = true;
				cardToHand.position = m_handPositions[i].HandPosition.position;
				cardToHand.GetComponent<CartaBase>().CurrentHandPosition = m_handPositions[i];
				m_handPositions[i].Card = cardToHand;
				break;
			}
		}
	}

	public void ReturnCardToHand(Transform cardToHand)
	{
		if (cardToHand.GetComponent<CartaBase>().CurrentHandPosition != null)
		{
			cardToHand.position = cardToHand.GetComponent<CartaBase>().CurrentHandPosition.HandPosition.position;
		}
	}

	public void FillHolesInHand()
	{
		for (int i = 0; i < m_handPositions.Length - 1; i++)
		{
			if (!m_handPositions[i].IsBeingUsed)
			{
				for (int j = i + 1; j < m_handPositions.Length; j++)
				{
					if (m_handPositions[j].IsBeingUsed)
					{
						m_handPositions[j].IsBeingUsed = false;
						m_handPositions[i].Card = m_handPositions[j].Card;
						m_handPositions[j].Card = null;
						m_handPositions[i].Card.position = m_handPositions[i].HandPosition.position;
						m_handPositions[i].IsBeingUsed = true;
						m_handPositions[i].Card.GetComponent<CartaBase>().CurrentHandPosition = m_handPositions[i];
						break;
					}
				}
			}
		}
	}

	public void ChangeCharHand()
	{
		for (int i = 0; i < m_handPositions.Length; i++)
		{
			if (m_handPositions[i].IsBeingUsed)
			{
				m_handPositions[i].Card.position = new Vector3(1000, 1000, 0);
				m_handPositions[i].Card.gameObject.SetActive(false);
				m_handPositions[i].Card = null;
				m_handPositions[i].IsBeingUsed = false;
			}
		}

		for (int j = 0; j < HandManager.Instance.CharDecks[HandManager.Instance.CurrentCharIndex].Hand.Count; j++)
		{
			m_handPositions[j].Card = HandManager.Instance.CharDecks[HandManager.Instance.CurrentCharIndex].Hand[j].transform;
			m_handPositions[j].Card.gameObject.SetActive(true);
			m_handPositions[j].Card.position = m_handPositions[j].HandPosition.position;
			m_handPositions[j].Card.GetComponent<CartaBase>().CurrentHandPosition = m_handPositions[j];
			m_handPositions[j].IsBeingUsed = true;
		}
	}
}
