using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(StatusComponent))]
public class EnemyBehaviour : MonoBehaviour
{
	[SerializeField] private List<EnemyAbility> m_abilities = new List<EnemyAbility>(0);

	[SerializeField] private int m_numberOfActionsPerTurn = 0;
	private int m_currentNumberOfActionsThisTurn = 0;

	private StatusComponent m_cmpStatus = null;

	public void Start()
	{
		m_cmpStatus = this.GetComponent<StatusComponent>();
	}

	public void Activate()
	{
		if(m_cmpStatus.CurrentEnemyStatus != EnemyStatus.Stunned)
		{
			//List<EnemyAbility> m_thing = new List<EnemyAbility>(0);

			List<EnemyAbility> m_availableAbilities = new List<EnemyAbility>(0);


			m_currentNumberOfActionsThisTurn = 0;


			while (m_numberOfActionsPerTurn > m_currentNumberOfActionsThisTurn)
			{
				int availablePoints = m_numberOfActionsPerTurn - m_currentNumberOfActionsThisTurn;

				for (int i = 0; i < m_abilities.Count; i++)
				{
					if (m_abilities[i].ActionCost <= availablePoints)
					{
						m_availableAbilities.Add(m_abilities[i]);
					}
				}

				if (m_availableAbilities.Count == 0)
				{
					break;
				}

				int rand = Random.Range(0, m_availableAbilities.Count);
				m_availableAbilities[rand].ActivateAbility();
				m_currentNumberOfActionsThisTurn = m_currentNumberOfActionsThisTurn + m_availableAbilities[rand].ActionCost;

				if(m_cmpStatus.CurrentEnemyStatus == EnemyStatus.Electrified)
				{
					this.GetComponent<VidaBase>().DealDamage(1);
				}
			}
		}
	}

	public void EndOfTurnStatus()
	{
		m_cmpStatus.EndOfTurnStatusUpdate();
	}

	public void BeginigOfTurnStatus()
	{
		m_cmpStatus.BeginingOfTurnStatusUpdate();
	}
}
