using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusComponent : MonoBehaviour
{
	private EnemyStatus m_currentEnemyStatus = EnemyStatus.None;

	private int m_isWetDuration = 0;
	private int m_isElectrifiedDuration = 0;
	private int m_isStunnedDuration = 0;

	[SerializeField] private TextMeshProUGUI m_txtDuration = null;

	[SerializeField] private Image m_StatusImg = null;

	[SerializeField] private Sprite m_stunSprite = null;
	[SerializeField] private Sprite m_wetSprite = null;
	[SerializeField] private Sprite m_electrifiedSprite = null;

	[SerializeField] private Color m_stunnedTextColor;
	[SerializeField] private Color m_wetTextColor;
	[SerializeField] private Color m_electrifiedTextColor;

	public EnemyStatus CurrentEnemyStatus { get => m_currentEnemyStatus; set => m_currentEnemyStatus = value; }
	public int IsElectrifiedDuration { get => m_isElectrifiedDuration; set => m_isElectrifiedDuration = value; }

	public void BeginingOfTurnStatusUpdate()
	{
		if(m_currentEnemyStatus == EnemyStatus.Wet)
		{
			m_isWetDuration = m_isWetDuration - 1;

			m_txtDuration.text = m_isWetDuration.ToString();

			if(m_isWetDuration == 0)
			{
				m_currentEnemyStatus = EnemyStatus.None;

				m_StatusImg.gameObject.SetActive(false);
				m_txtDuration.gameObject.SetActive(false);
			}
		}
	}

	public void EndOfTurnStatusUpdate()
	{
		if (m_currentEnemyStatus == EnemyStatus.Stunned)
		{
			m_isStunnedDuration = m_isStunnedDuration - 1;
			m_txtDuration.text = m_isStunnedDuration.ToString();

			if (m_isStunnedDuration == 0)
			{
				m_currentEnemyStatus = EnemyStatus.None;

				m_StatusImg.gameObject.SetActive(false);
				m_txtDuration.gameObject.SetActive(false);
			}
		}

		if (m_currentEnemyStatus == EnemyStatus.Electrified)
		{
			m_isElectrifiedDuration = m_isElectrifiedDuration - 1;
			m_txtDuration.text = m_isElectrifiedDuration.ToString();

			if (m_isElectrifiedDuration == 0)
			{
				m_currentEnemyStatus = EnemyStatus.None;

				m_StatusImg.gameObject.SetActive(false);
				m_txtDuration.gameObject.SetActive(false);
			}
		}
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


		m_txtDuration.gameObject.SetActive(true);
		m_txtDuration.text = m_isStunnedDuration + "";
		m_txtDuration.color = m_stunnedTextColor;

		m_StatusImg.gameObject.SetActive(true);
		m_StatusImg.sprite = m_stunSprite;
		
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
					m_isElectrifiedDuration = m_isElectrifiedDuration + numberOfTurns;

					m_txtDuration.gameObject.SetActive(true);
					m_txtDuration.text = m_isElectrifiedDuration + "";
					m_txtDuration.color = m_electrifiedTextColor;

					m_StatusImg.gameObject.SetActive(true);
					m_StatusImg.sprite = m_electrifiedSprite;
				}
				break;
			case EnemyStatus.Stunned:
				{

				}
				break;
			case EnemyStatus.None:
				{
					m_isElectrifiedDuration = numberOfTurns;
					m_currentEnemyStatus = EnemyStatus.Electrified;

					m_txtDuration.gameObject.SetActive(true);
					m_txtDuration.text = m_isElectrifiedDuration + "";
					m_txtDuration.color = m_electrifiedTextColor;

					m_StatusImg.gameObject.SetActive(true);
					m_StatusImg.sprite = m_electrifiedSprite;
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
					m_txtDuration.text = m_isWetDuration.ToString();

					m_txtDuration.gameObject.SetActive(true);
					m_txtDuration.text = m_isWetDuration + "";
					m_txtDuration.color = m_wetTextColor;

					m_StatusImg.gameObject.SetActive(true);
					m_StatusImg.sprite = m_wetSprite;
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
					m_StatusImg.sprite = m_wetSprite;

					m_txtDuration.gameObject.SetActive(true);
					m_txtDuration.text = m_isWetDuration + "";
					m_txtDuration.color = m_wetTextColor;

					m_StatusImg.gameObject.SetActive(true);
					m_StatusImg.sprite = m_wetSprite;
				}
				break;
			default:
				break;
		}

		
	}

}
