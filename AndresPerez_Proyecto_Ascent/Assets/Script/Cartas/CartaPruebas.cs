using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaPruebas : CartaBase
{
	[SerializeField] private int m_damage = 0;
	public override void Effect()
	{
		FindObjectOfType<VidaEnemigo>().DealDamage(m_damage);
	}
}
