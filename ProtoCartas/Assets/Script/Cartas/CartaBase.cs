using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CartaBase : MonoBehaviour
{
	protected HandPositionData m_currentHandPosition = null;

	protected CardState m_currentCardState = CardState.EnMano;

	public CardState CurrentCardState { get => m_currentCardState; set => m_currentCardState = value; }
	public HandPositionData CurrentHandPosition { get => m_currentHandPosition; set => m_currentHandPosition = value; }

	private void Start()
	{
		
	}

	private void Update()
	{
		switch (m_currentCardState)
		{
			case CardState.EnMano:
				break;
			case CardState.Seleccionada:
				{
					Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					this.transform.position = new Vector3(mousePos.x, mousePos.y, this.transform.position.z);
				}
				break;
			case CardState.None:
				break;
			default:
				break;
		}
	}


	public abstract void Effect();


}
