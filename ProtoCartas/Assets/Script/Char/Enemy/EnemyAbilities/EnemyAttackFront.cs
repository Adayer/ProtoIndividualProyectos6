using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackFront : EnemyAbility
{
	[SerializeField] private int m_damage = 0;

	public override void ActivateAbility()
	{
		CharacterManager.Instance.Characters[HandManager.Instance.CurrentCharIndex].GetComponent<VidaBase>().DealDamage(m_damage);
	}
}
