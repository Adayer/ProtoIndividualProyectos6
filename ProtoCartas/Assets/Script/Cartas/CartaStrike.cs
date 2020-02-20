using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaStrike : CartaBase
{
	[SerializeField] private int m_damage = 0;

	public override void Effect()
	{
		EnemyManager.Instance.Enemy.gameObject.GetComponent<VidaBase>().DealDamage(m_damage);
	}
}
