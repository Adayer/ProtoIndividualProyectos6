using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTurnos : TemporalSingleton<ManagerTurnos>
{
	[SerializeField] private TurnPhase m_currentTurnPhase = TurnPhase.None;


    void Update()
    {
		switch (m_currentTurnPhase)
		{
			case TurnPhase.InicioTurno:
				break;
			case TurnPhase.Actuando:
				break;
			case TurnPhase.FinalDeTurno:
				break;
			case TurnPhase.None:
				break;
			default:
				break;
		}
	}
}
