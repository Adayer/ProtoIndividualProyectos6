using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInHandManager : TemporalSingleton<PositionInHandManager>
{
	[SerializeField] private HandPositionData[] m_handPositions = new HandPositionData[0];
	
	public void PlaceCardInHand(Transform cardToHand)
	{
		for (int i = 0; i < m_handPositions.Length; i++)
		{
			if(cardToHand.GetComponent<CartaBase>().CurrentHandPosition != null)
			{
				cardToHand.position = cardToHand.GetComponent<CartaBase>().CurrentHandPosition.HandPosition.position;
				break;
			}
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
}
