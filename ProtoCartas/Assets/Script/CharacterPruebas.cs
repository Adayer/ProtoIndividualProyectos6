using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPruebas : CharacterComponent
{
	public override void CharacterAbility(bool isFrontCharacter)
	{
		if (isFrontCharacter)
		{
			print("THIS IS MY FINAL ABILITY");
		}
		else
		{
			print("Just you wait for my final form");
		}
		
		//Ability needs to be implemented
	}

}
