using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterComponent : MonoBehaviour
{
	[SerializeField] protected TypeOfCharAbility m_typeOfAbility = TypeOfCharAbility.None;

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

	public abstract void CharacterAbility(bool isFrontCharacter);
}
