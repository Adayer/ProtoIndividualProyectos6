using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTurnos : TemporalSingleton<ManagerTurnos>
{
	[SerializeField] private TurnPhase m_currentTurnPhase = TurnPhase.None;

	[SerializeField] private float m_maxTurnDuration = 0f;
	private float m_currentTurnDuration = 0f;

	[SerializeField] private Image m_timeBar = null;

	bool notFirstTurn = false;
	
	public TurnPhase CurrentTurnPhase { get => m_currentTurnPhase; set => m_currentTurnPhase = value; }

	void Update()
    {
		switch (m_currentTurnPhase)
		{
			case TurnPhase.InicioTurnoPlayer:
				{
					print("Habilidades en el script CharacterComponent");
					//Deal effects to players
					m_currentTurnPhase = TurnPhase.ActuandoPlayer;
					m_currentTurnDuration = m_maxTurnDuration;

					if (notFirstTurn)
					{
						HandManager.Instance.StartTurnDraw();
					}

					CharacterManager.Instance.DealStartOfTurnEffects();
					CharacterManager.Instance.BeginingOfTurnStatus();

					HandManager.Instance.CheckDiscardAtEndOfTurn();

					HandManager.Instance.ResetMana();
					m_timeBar.transform.parent.gameObject.SetActive(true);
				}
				break;
			case TurnPhase.ActuandoPlayer:
				{
					m_currentTurnDuration = m_currentTurnDuration - Time.deltaTime;

					m_timeBar.fillAmount = m_currentTurnDuration / m_maxTurnDuration;

					if(m_currentTurnDuration <= 0)
					{
						m_currentTurnPhase = TurnPhase.FinalDeTurnoPlayer;
						m_currentTurnDuration = 0;
					}
				}
				break;
			case TurnPhase.FinalDeTurnoPlayer:
				{
					m_timeBar.transform.parent.gameObject.SetActive(false);

					SelectorDeCartas.Instance.ReturnCardToHand();

					CharacterManager.Instance.DealEndOfTurnEffects();
					CharacterManager.Instance.EndOfTurnStatus();

					HandManager.Instance.CheckDiscardAtEndOfTurn();
					//Descartar cartas extra
					m_currentTurnPhase = TurnPhase.InicioTurnoEnemy;
				}
				break;
			case TurnPhase.InicioTurnoEnemy:
				{
					EnemyManager.Instance.BeginingOfTurnStatus();
					m_currentTurnPhase = TurnPhase.ActuandoEnemy;
				}
				break;
			case TurnPhase.ActuandoEnemy:
				{
					EnemyManager.Instance.EnemyAct ();
					m_currentTurnPhase = TurnPhase.FinalDeTurnoEnemy;
				}
				break;
			case TurnPhase.FinalDeTurnoEnemy:
				{
					EnemyManager.Instance.EndOfTurnStatus();
					m_currentTurnPhase = TurnPhase.InicioTurnoPlayer;
					notFirstTurn = true;
				}
				break;
			case TurnPhase.None:
				break;
			default:
				break;
		}
	}
	public void EndPlayerTurn()
	{
		if(m_currentTurnPhase == TurnPhase.ActuandoPlayer)
		{
			m_currentTurnPhase = TurnPhase.FinalDeTurnoPlayer;
		}
	}

	IEnumerator Wait()
	{
	    new WaitForSeconds(100);

		yield return null;
	}
}
