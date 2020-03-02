using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatusComponent))]
public abstract class CharacterComponent : MonoBehaviour
{
	[SerializeField] protected TypeOfCharAbility m_typeOfAbility = TypeOfCharAbility.None;

	private StatusComponent m_cmpStatus = null;

	private void Start()
	{
		m_cmpStatus = this.GetComponent<StatusComponent>();
	}

	public void StartOfTurnEffects(bool isFrontCharacter)
	{
		if(m_typeOfAbility == TypeOfCharAbility.StartOfTurn)
		{
			CharacterAbility(isFrontCharacter);
		}
		//All buffs and debuffs that take place during this phase should take place now;
	}

	public void EndOfTurnEffects(bool isFrontCharacter)
	{
		if(m_typeOfAbility == TypeOfCharAbility.EndOfTurn)
		{
			CharacterAbility(isFrontCharacter);
		}
		//All buffs and debuffs that take place during this phase should take place now;
	}


	public void EndOfTurnStatus()
	{
		m_cmpStatus.EndOfTurnStatusUpdate();
	}

	public void BeginigOfTurnStatus()
	{
		m_cmpStatus.BeginingOfTurnStatusUpdate();
	}

	public abstract void CharacterAbility(bool isFrontCharacter);
}
