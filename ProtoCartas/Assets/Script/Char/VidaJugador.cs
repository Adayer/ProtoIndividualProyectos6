using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaBase
{
	public void Heal(int healAmmount)
	{
		m_currentLife = m_currentLife + healAmmount;

		if(m_currentLife > m_maxLife)
		{
			m_currentLife = m_maxLife;
		}

		m_lifeTxt.text = m_currentLife.ToString();
		m_lifeImg.fillAmount = m_currentLife / m_maxLife;
	}
}
