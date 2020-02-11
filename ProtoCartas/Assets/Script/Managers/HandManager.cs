using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandManager : TemporalSingleton<HandManager>
{
	[SerializeField] private CharacterDecksData[] m_charDecks = new CharacterDecksData[0];
	int m_currentCharIndex = 0;
	
	private bool m_handIsFull = false;

	[SerializeField] private int m_cardsDrawnAtTheStartOfCombat = 0;
	[SerializeField] private int m_charNotInFrontCardsDrawnAtTheStartOfCombat = 0;

	[SerializeField] private int m_maxNumberOfCardsInHand = 0;
	private int m_currentNumberOfCardsInHand = 0;


	[SerializeField] private TextMeshProUGUI m_deckSizeTxt = null;
	[SerializeField] private TextMeshProUGUI m_discardPileSizeTxt = null;

	public bool HandIsFull { get => m_handIsFull; set => m_handIsFull = value; }
	public int CurrentNumberOfCardsInHand { get => m_currentNumberOfCardsInHand; set => m_currentNumberOfCardsInHand = value; }
	public CharacterDecksData[] CharDecks { get => m_charDecks; set => m_charDecks = value; }

	private void Start()
	{

		for (int i = 0; i < m_charDecks.Length; i++)
		{
			m_charDecks[i].DiscardPile = new List<GameObject>(0);
			m_charDecks[i].DeckOfCards = new List<GameObject>(0);
			m_charDecks[i].Hand = new List<GameObject>(0);
		}

		for (int i = 0; i < m_charDecks.Length; i++)
		{
			for (int j = 0; j < m_charDecks[i].DeckOfCardsSO.Count; j++)
			{
				GameObject card = Instantiate(m_charDecks[i].DeckOfCardsSO[j], new Vector3(1000f, 1000f, 0f), Quaternion.identity);
				m_charDecks[i].DeckOfCards.Add(card);
				card.SetActive(false);
			}
		}


		for (int i = 0; i < m_cardsDrawnAtTheStartOfCombat; i++)
		{
			DrawCard();
		}

		print(m_currentCharIndex);

		switch (m_currentCharIndex)
		{
			case 0:
				{
					for (int i = 0; i < m_charNotInFrontCardsDrawnAtTheStartOfCombat; i++)
					{
						DrawCardNotFront(1);
					}

					for (int i = 0; i < m_charNotInFrontCardsDrawnAtTheStartOfCombat; i++)
					{
						DrawCardNotFront(2);
					}
				}
				break;
			case 1:
				{
					for (int i = 0; i < m_charNotInFrontCardsDrawnAtTheStartOfCombat; i++)
					{
						DrawCardNotFront(0);
					}

					for (int i = 0; i < m_charNotInFrontCardsDrawnAtTheStartOfCombat; i++)
					{
						DrawCardNotFront(2);
					}
				}
				break;
			case 2:
				{
					for (int i = 0; i < m_charNotInFrontCardsDrawnAtTheStartOfCombat; i++)
					{
						DrawCardNotFront(0);
					}

					for (int i = 0; i < m_charNotInFrontCardsDrawnAtTheStartOfCombat; i++)
					{
						DrawCardNotFront(1);
					}
				}
				break;
			default:
				break;
		}

	}

	private void Update()
	{
		m_deckSizeTxt.text = m_charDecks[m_currentCharIndex].DeckOfCards.Count.ToString();
		m_discardPileSizeTxt.text = m_charDecks[m_currentCharIndex].DiscardPile.Count.ToString();
	}


	public void DrawCard()
	{
		if(m_charDecks[m_currentCharIndex].DeckOfCards.Count > 0)
		{
			if (m_currentNumberOfCardsInHand < m_maxNumberOfCardsInHand)
			{
				m_currentNumberOfCardsInHand = m_currentNumberOfCardsInHand + 1;

				int index = Random.Range(0, m_charDecks[m_currentCharIndex].DeckOfCards.Count);
				GameObject cardDrawn = m_charDecks[m_currentCharIndex].DeckOfCards[index];

				m_charDecks[m_currentCharIndex].DeckOfCards.RemoveAt(index);

				cardDrawn.SetActive(true);
				PositionInHandManager.Instance.PlaceCardInHand(cardDrawn.transform);

				m_charDecks[m_currentCharIndex].Hand.Add(cardDrawn);

				if(m_charDecks[m_currentCharIndex].DeckOfCards.Count == 0)
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

	public void DrawCardNotFront(int charIndex)
	{
		if (m_charDecks[charIndex].DeckOfCards.Count > 0)
		{
			//Aqui esta el problema tengo que ver si el numero de cartas en la mano es el del personaje que esta robando no del personaje que esta delante.
			if (m_currentNumberOfCardsInHand < m_maxNumberOfCardsInHand)
			{
				m_currentNumberOfCardsInHand = m_currentNumberOfCardsInHand + 1;

				int index = Random.Range(0, m_charDecks[charIndex].DeckOfCards.Count);
				GameObject cardDrawn = m_charDecks[charIndex].DeckOfCards[index];

				m_charDecks[charIndex].DeckOfCards.RemoveAt(index);

				m_charDecks[charIndex].Hand.Add(cardDrawn);

				print(cardDrawn.name);

				if (m_charDecks[charIndex].DeckOfCards.Count == 0)
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

		m_charDecks[m_currentCharIndex].DiscardPile.Add(discaredCard);
		m_charDecks[m_currentCharIndex].Hand.Remove(discaredCard);

		m_currentNumberOfCardsInHand = m_currentNumberOfCardsInHand - 1;

		ResetDrawPile();
	}

	public void ResetDrawPile()
	{
		if(m_charDecks[m_currentCharIndex].DiscardPile.Count > 0)
		{
			if (m_charDecks[m_currentCharIndex].DeckOfCards.Count == 0)
			{
				for (int i = 0; i < m_charDecks[m_currentCharIndex].DiscardPile.Count; i++)
				{
					m_charDecks[m_currentCharIndex].DeckOfCards.Add(m_charDecks[m_currentCharIndex].DiscardPile[i]);
				}

				m_charDecks[m_currentCharIndex].DiscardPile = new List<GameObject>(0);
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
	public void ResetDrawPileNotFront(int index)
	{
		if (m_charDecks[index].DiscardPile.Count > 0)
		{
			if (m_charDecks[index].DeckOfCards.Count == 0)
			{
				for (int i = 0; i < m_charDecks[index].DiscardPile.Count; i++)
				{
					m_charDecks[m_currentCharIndex].DeckOfCards.Add(m_charDecks[index].DiscardPile[i]);
				}

				m_charDecks[index].DiscardPile = new List<GameObject>(0);
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


	public void ChangeToLeftChar()
	{
		if(m_currentCharIndex == 0)
		{
			m_currentCharIndex = m_charDecks.Length - 1;
		}
		else
		{
			m_currentCharIndex = m_currentCharIndex - 1;
		}
		PositionInHandManager.Instance.ChangeCharHand();
	}
	public void ChangeToRightChar()
	{
		if(m_currentCharIndex >= m_charDecks.Length - 1)
		{
			m_currentCharIndex = 0;
		}
		else
		{
			m_currentCharIndex = m_currentCharIndex + 1;
		}
		PositionInHandManager.Instance.ChangeCharHand();
	}
}
