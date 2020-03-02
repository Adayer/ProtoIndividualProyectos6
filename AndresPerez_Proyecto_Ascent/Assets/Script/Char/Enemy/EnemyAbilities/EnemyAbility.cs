using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbility : MonoBehaviour
{
	[SerializeField] protected int actionCost = 0;

	public int ActionCost { get => actionCost; set => actionCost = value; }

	public abstract void ActivateAbility();
}
