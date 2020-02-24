using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMove : EnemyAbility
{
	[SerializeField] private int m_damage = 0;
	[SerializeField] private bool m_movesRight = false;

	public override void ActivateAbility()
	{
		CharacterManager.Instance.Characters[HandManager.Instance.CurrentCharIndex].GetComponent<VidaBase>().DealDamage(m_damage);

		if (m_movesRight)
		{
			HandManager.Instance.ChangeToRightCharByEnemy();
		}
		else
		{
			HandManager.Instance.ChangeToLeftCharByEnemy();
		}

		CharacterManager.Instance.Characters[HandManager.Instance.CurrentCharIndex].GetComponent<VidaBase>().DealDamage(m_damage);
	}
}
