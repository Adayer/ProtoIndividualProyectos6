using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaHealElectrify : CartaBase
{
	[SerializeField] private int m_numberOfTurnsElectrified = 0;

	public override void Effect()
	{
		EnemyManager.Instance.Enemy.CmpStatus.Electrify(m_numberOfTurnsElectrified);
	}
}
