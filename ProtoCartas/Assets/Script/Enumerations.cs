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

public enum EnemyStatus
{
	Wet, Electrified, Stunned, None //If wet: recieve extra damage from lighting sources; If electrified: take 1 dmg each time he uses and ability; if Stunned: doesn't take his turn.
}