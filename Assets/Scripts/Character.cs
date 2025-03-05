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
    public int proficiencyBonus;
    public AbilityScore strength;
    public AbilityScore dexterity;
    public AbilityScore constitution;
    public AbilityScore intelligence;
    public AbilityScore wisdom;
    public AbilityScore charisma;
    public Weapon weapon;

    public virtual void InitializePlayerCharacter()
    {}

    public virtual int DoAttackRoll()
    {
        int attackRoll = Rng_System.RollDice(20, 1, proficiencyBonus + strength.GetModifier());
        Debug.Log("proficiency bonus " + proficiencyBonus);
        Debug.Log("strength modifier " + strength.GetModifier());
        Debug.Log(characterName + " attacks with a roll of " + attackRoll);
        return attackRoll;
    }

    public virtual int DoDamageRoll() {return 0;}


}
