using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : TemporalSingleton<EnemyManager>
{
	[SerializeField] private EnemyBehaviour m_enemy = null;
	
	public EnemyBehaviour Enemy { get => m_enemy; set => m_enemy = value; }

	public void EnemyAct()
	{
		m_enemy.Activate();
	}
}
