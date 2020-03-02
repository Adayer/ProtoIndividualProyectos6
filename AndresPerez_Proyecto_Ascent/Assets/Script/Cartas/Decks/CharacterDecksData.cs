using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Decks Data", menuName = "Character Decks Data", order = 51)]
[System.Serializable]
public class CharacterDecksData : ScriptableObject
{
	[SerializeField] private List<GameObject> m_deckOfCardsSO = new List<GameObject>(0);
	private List<GameObject> m_deckOfCards = new List<GameObject>(0);
	private List<GameObject> m_discardPile = new List<GameObject>(0);
	private List<GameObject> m_hand = new List<GameObject>(0);
	

	public List<GameObject> DiscardPile { get => m_discardPile; set => m_discardPile = value; }
	public List<GameObject> DeckOfCards { get => m_deckOfCards; set => m_deckOfCards = value; }
	public List<GameObject> Hand { get => m_hand; set => m_hand = value; }
	public List<GameObject> DeckOfCardsSO { get => m_deckOfCardsSO; set => m_deckOfCardsSO = value; }
}
