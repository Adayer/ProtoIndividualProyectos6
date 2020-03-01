using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectorDeCartas : TemporalSingleton<SelectorDeCartas>
{
	[SerializeField] private LayerMask m_cardPlaceLayerMask;
	[SerializeField] private LayerMask m_cardSelectLayerMask;

	[SerializeField] private GameObject[] m_botones = new GameObject[0];


	private CartaBase m_selectedCard = null;
	private bool m_hasCardSelected = false;


	// Update is called once per frame
	void Update()
	{
		if (ManagerTurnos.Instance.CurrentTurnPhase == TurnPhase.ActuandoPlayer)
		{
			if (!m_hasCardSelected)
			{
				if (Input.GetMouseButtonDown(0))
				{
					Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					RaycastHit2D hit = Physics2D.Raycast(new Vector3(mousePos.x, mousePos.y, mousePos.z - 10), Camera.main.transform.forward, Mathf.Infinity, m_cardSelectLayerMask);
					if (hit.collider != null)
					{
						if (hit.collider.GetComponent<CartaBase>() != null)
						{
							if (HandManager.Instance.CheckMana(hit.collider.GetComponent<CartaBase>().ManaCost))
							{
								m_selectedCard = hit.collider.GetComponent<CartaBase>();
								m_selectedCard.CurrentCardState = CardState.Seleccionada;
								m_hasCardSelected = true;

								for (int i = 0; i < m_botones.Length; i++)
								{
									m_botones[i].SetActive(false);
								}
							}
						}
					}
				}
			}
			else
			{
				if (Input.GetMouseButtonDown(0))
				{
					Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					RaycastHit2D hit = Physics2D.Raycast(new Vector3(mousePos.x, mousePos.y, mousePos.z - 10), Camera.main.transform.forward, Mathf.Infinity, m_cardPlaceLayerMask);
					if (hit.collider != null)
					{
						if (hit.collider.gameObject.layer == CardPlacementeLayers.TableLayer)
						{
							m_selectedCard.Effect();

							HandManager.Instance.SpendMana(m_selectedCard.ManaCost);

							if (m_selectedCard.CurrentHandPosition != null)
							{
								m_selectedCard.CurrentHandPosition.IsBeingUsed = false;
								m_selectedCard.CurrentHandPosition.Card = null;
								m_selectedCard.CurrentHandPosition = null;
							}

							m_selectedCard.CurrentCardState = CardState.EnMano;
							HandManager.Instance.DiscardCard(m_selectedCard.gameObject);
							m_selectedCard = null;
							m_hasCardSelected = false;
							PositionInHandManager.Instance.FillHolesInHand();

							for (int i = 0; i < m_botones.Length; i++)
							{
								m_botones[i].SetActive(true);
							}
						}
						else if (hit.collider.gameObject.layer == CardPlacementeLayers.HandLayer)
						{
							m_selectedCard.CurrentCardState = CardState.EnMano;
							PositionInHandManager.Instance.ReturnCardToHand(m_selectedCard.transform);
							m_selectedCard = null;
							m_hasCardSelected = false;

							for (int i = 0; i < m_botones.Length; i++)
							{
								m_botones[i].SetActive(true);
							}
						}
					}
				}
			}
		}
	}

	public void ReturnCardToHand()
	{
		if (m_hasCardSelected)
		{
			m_selectedCard.CurrentCardState = CardState.EnMano;
			PositionInHandManager.Instance.ReturnCardToHand(m_selectedCard.transform);
			m_selectedCard = null;
			m_hasCardSelected = false;

			for (int i = 0; i < m_botones.Length; i++)
			{
				m_botones[i].SetActive(true);
			}
		}
	}
}
