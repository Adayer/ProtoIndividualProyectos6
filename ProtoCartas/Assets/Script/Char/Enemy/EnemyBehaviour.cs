using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	[SerializeField] private List<EnemyAbility> m_abilities = new List<EnemyAbility>(0);
	private List<EnemyAbility> m_availableAbilities = new List<EnemyAbility>(0);


	[SerializeField] private int m_numberOfActionsPerTurn = 0;
	private int m_currentNumberOfActionsThisTurn = 0;
	

	public void Activate()
	{
		m_availableAbilities = m_abilities;

		m_currentNumberOfActionsThisTurn = 0;

		while(m_numberOfActionsPerTurn > m_currentNumberOfActionsThisTurn)
		{
			for (int i = (m_availableAbilities.Count - 1); i < 0; i--)
			{
				if(m_availableAbilities[i].ActionCost <= (m_numberOfActionsPerTurn- m_currentNumberOfActionsThisTurn))
				{
					m_availableAbilities.RemoveAt(i);
				}

				
			}
			

			if(m_availableAbilities.Count == 0)
			{
				break;
			}

			int rand = Random.Range(0, m_availableAbilities.Count);
			m_availableAbilities[rand].ActivateAbility();
			m_currentNumberOfActionsThisTurn = m_currentNumberOfActionsThisTurn + m_availableAbilities[rand].ActionCost;
		}
	}
}
