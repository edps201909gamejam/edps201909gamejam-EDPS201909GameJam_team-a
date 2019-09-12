using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create StatusData")]
public class Status : ScriptableObject
{
	public string name;
	public int maxHp;
	public int atk;
}
