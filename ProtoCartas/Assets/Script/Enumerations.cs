using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnPhase
{
	InicioTurnoPlayer, ActuandoPlayer, FinalDeTurnoPlayer, InicioTurnoEnemy, ActuandoEnemy, FinalDeTurnoEnemy, None
}

public enum CardState
{
	EnMano, Seleccionada, None
}

public enum TypeOfCharAbility
{
	StartOfTurn, EndOfTurn, None 
}