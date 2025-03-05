using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{ 
    public string characterName;
    public int level;
    public int exp;
    public int armorClass;
    public int hitPoints;
    public int hitPointsMax;
    public AbilityScore strength;
    public AbilityScore dexterity;
    public AbilityScore constitution;
    public AbilityScore intelligence;
    public AbilityScore wisdom;
    public AbilityScore charisma;
    public Weapon weapon;
}
