using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusComponent : MonoBehaviour
{
	private EnemyStatus m_currentEnemyStatus = EnemyStatus.None;

	private int m_isWetDuration = 0;
	private int m_isElectriffiedDuration = 0;
	private int m_isStunnedDuration = 0;

	public EnemyStatus CurrentEnemyStatus { get => m_currentEnemyStatus; set => m_currentEnemyStatus = value; }

	public void BeginingOfTurnStatusUpdate()
	{
		if(m_currentEnemyStatus == EnemyStatus.Wet)
		{
			m_isWetDuration = m_isWetDuration - 1;
			if(m_isWetDuration == 0)
			{
				m_currentEnemyStatus = EnemyStatus.None;
			}
		}

		if (m_currentEnemyStatus == EnemyStatus.Stunned)
		{
			m_isStunnedDuration = m_isStunnedDuration - 1;
			if (m_isStunnedDuration == 0)
			{
				m_currentEnemyStatus = EnemyStatus.None;
			}
		}

		if (m_currentEnemyStatus == EnemyStatus.Electrified)
		{
			m_isElectriffiedDuration = m_isElectriffiedDuration - 1;
			if (m_isElectriffiedDuration == 0)
			{
				m_currentEnemyStatus = EnemyStatus.None;
			}
		}
	}

	public void EndOfTurnStatusUpdate()
	{

	}


	public void Stun(int numberOfTurns)
	{
		if (m_currentEnemyStatus == EnemyStatus.Stunned)
		{
			m_isStunnedDuration = m_isStunnedDuration + numberOfTurns;
		}
		else
		{
			m_isStunnedDuration = numberOfTurns;
			m_currentEnemyStatus = EnemyStatus.Stunned;
		}
	}
	public void Electrify(int numberOfTurns)
	{
		switch (m_currentEnemyStatus)
		{
			case EnemyStatus.Wet:
				{
					Stun(1);
					m_isWetDuration = 0;
				}
				break;
			case EnemyStatus.Electrified:
				{
					m_isElectriffiedDuration = m_isElectriffiedDuration + numberOfTurns;
				}
				break;
			case EnemyStatus.Stunned:
				{

				}
				break;
			case EnemyStatus.None:
				{
					m_isElectriffiedDuration = numberOfTurns;
					m_currentEnemyStatus = EnemyStatus.Electrified;
				}
				break;
			default:
				break;
		}
	}
	public void Wet(int numberOfTurns)
	{
		switch (m_currentEnemyStatus)
		{
			case EnemyStatus.Wet:
				{
					m_isWetDuration = m_isWetDuration + numberOfTurns;
				}
				break;
			case EnemyStatus.Electrified:
				{
					Stun(1);
				}
				break;
			case EnemyStatus.Stunned:
				{

				}
				break;
			case EnemyStatus.None:
				{
					m_isWetDuration = numberOfTurns;
					m_currentEnemyStatus = EnemyStatus.Wet;
				}
				break;
			default:
				break;
		}
	}
}
