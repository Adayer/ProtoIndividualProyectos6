﻿using System.Collections;
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

	[SerializeField] private ParticleSystem m_impactParticles = null;

	private void Awake()
	{
		m_currentLife = m_maxLife;
		m_lifeTxt.text = m_currentLife.ToString();
		m_lifeImg.fillAmount = (float)m_currentLife / (float)m_maxLife;

	}

	public void DealDamage(int damage)
	{
		if (this.GetComponent<EnemyBehaviour>() != null)
		{
			m_currentLife = m_currentLife - damage;
		}
		else
		{
			m_currentLife = m_currentLife - damage;
		}

		if(m_currentLife <= 0)
		{
			print("Someone died");
			m_currentLife = 0;
		}

		m_impactParticles.Play();

		m_lifeTxt.text = m_currentLife.ToString();
		m_lifeImg.fillAmount = (float)m_currentLife / (float)m_maxLife;
	}
}
