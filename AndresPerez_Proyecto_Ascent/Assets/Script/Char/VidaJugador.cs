using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaBase
{
	[SerializeField] private ParticleSystem m_healPartciles = null;
	public void Heal(int healAmmount)
	{
		m_currentLife = m_currentLife + healAmmount;

		if(m_currentLife > m_maxLife)
		{
			m_currentLife = m_maxLife;
		}

		m_healPartciles.Play();

		m_lifeTxt.text = m_currentLife.ToString();
		m_lifeImg.fillAmount = (float)m_currentLife / (float)m_maxLife;
	}
}
