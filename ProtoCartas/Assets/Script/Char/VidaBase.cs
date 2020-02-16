using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaBase : MonoBehaviour
{
	[SerializeField] protected int m_maxLife = 0;
	protected int m_currentLife = 0;


	[SerializeField] protected TextMeshProUGUI m_lifeTxt = null;
	[SerializeField] protected Image m_lifeImg = null;

	private void Awake()
	{
		m_currentLife = m_maxLife;
		m_lifeTxt.text = m_currentLife.ToString();
		m_lifeImg.fillAmount = m_currentLife / m_maxLife;

	}

	public void DealDamage(int damage)
	{
		m_currentLife = m_currentLife - damage;

		if(m_currentLife <= 0)
		{
			print("Someone died");
			m_currentLife = 0;
		}
		m_lifeTxt.text = m_currentLife.ToString();
		m_lifeImg.fillAmount = m_currentLife / m_maxLife;
	}
}
