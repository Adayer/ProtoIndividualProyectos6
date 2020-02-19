using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	[SerializeField] private List<EnemyAbility> m_abilities = new List<EnemyAbility>(0);

	public void ChoosePower()
	{
		int rand = Random.Range(0, m_abilities.Count);
		m_abilities[rand].Ability();
	}
}
