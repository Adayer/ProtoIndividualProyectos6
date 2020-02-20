using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaSelfHeal : CartaBase
{
	[SerializeField] private int m_healAmmount = 0;

	public override void Effect()
	{
		CharacterManager.Instance.Characters[HandManager.Instance.CurrentCharIndex].gameObject.GetComponent<VidaJugador>().Heal(m_healAmmount);
	}
}
