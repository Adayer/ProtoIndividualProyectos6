using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandManager : TemporalSingleton<HandManager>
{
	[SerializeField] private List<GameObject> m_deckOfCards = new List<GameObject>(0);
	private List<GameObject> m_discardPile = new List<GameObject> (0);

	private bool m_handIsFull = false;

	[SerializeField] private int m_cardsDrawnAtTheStartOfCombat = 0;

	[SerializeField] private int m_maxNumberOfCardsInHand = 0;
	private int m_currentNumberOfCardsInHand = 0;


	[SerializeField] private TextMeshProUGUI m_deckSizeTxt = null;
	[SerializeField] private TextMeshProUGUI m_discardPileSizeTxt = null;

	public List<GameObject> DiscardPile { get => m_discardPile; set => m_discardPile = value; }
	public List<GameObject> DeckOfCards { get => m_deckOfCards; set => m_deckOfCards = value; }
	public bool HandIsFull { get => m_handIsFull; set => m_handIsFull = value; }

	private void Start()
	{
		for (int i = 0; i < m_cardsDrawnAtTheStartOfCombat; i++)
		{
			DrawCard();
		}
	}

	private void Update()
	{
		m_deckSizeTxt.text = m_deckOfCards.Count.ToString();
		m_discardPileSizeTxt.text = m_discardPile.Count.ToString();
	}


	public void DrawCard()
	{
		if(m_deckOfCards.Count > 0)
		{
			if (m_currentNumberOfCardsInHand < m_maxNumberOfCardsInHand)
			{
				m_currentNumberOfCardsInHand = m_currentNumberOfCardsInHand + 1;

				int index = Random.Range(0, m_deckOfCards.Count);
				GameObject cardDrawn = m_deckOfCards[index];

				m_deckOfCards.RemoveAt(index);

				cardDrawn.SetActive(true);
				PositionInHandManager.Instance.PlaceCardInHand(cardDrawn.transform);

				if(m_deckOfCards.Count == 0)
				{
					ResetDrawPile();
				}
			}
			else
			{
				print("No se puede robar más");
			}
		}
		else
		{
			ResetDrawPile();
		}
	}
	
	public void DiscardCard(GameObject discaredCard)
	{
		discaredCard.transform.Translate(Vector2.up * 1000);
		discaredCard.SetActive(false);

		m_discardPile.Add(discaredCard);

		m_currentNumberOfCardsInHand = m_currentNumberOfCardsInHand - 1;

		ResetDrawPile();
	}

	public void ResetDrawPile()
	{
		if(m_discardPile.Count > 0)
		{
			if (m_deckOfCards.Count == 0)
			{
				for (int i = 0; i < m_discardPile.Count; i++)
				{
					m_deckOfCards.Add(m_discardPile[i]);
				}

				m_discardPile = new List<GameObject>(0);
			}
			else
			{
				print("Todavía hay cartas");
			}
		}
		else
		{
			print("No hay más cartas");
		}
		
	}
}
