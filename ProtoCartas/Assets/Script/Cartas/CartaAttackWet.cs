using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaAttackWet : CartaBase
{
	[SerializeField] private int m_numberOfTurnsWet = 0;

	public override void Effect()
	{
		EnemyManager.Instance.Enemy.CmpStatus.Wet(m_numberOfTurnsWet);
	}
}
