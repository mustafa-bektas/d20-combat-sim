using UnityEngine;

public class FighterCharacter : Character
{
    void Start()
    {
        
    }

    public override void InitializePlayerCharacter()
    {
        strength = new AbilityScore();
        dexterity = new AbilityScore();
        constitution = new AbilityScore();
        intelligence = new AbilityScore();
        wisdom = new AbilityScore();
        charisma = new AbilityScore();

        strength.SetScore(16);
        dexterity.SetScore(14);
        constitution.SetScore(15);
        intelligence.SetScore(10);
        wisdom.SetScore(12);
        charisma.SetScore(8);

        armorClass = 18;
        hitPoints = 12;
        hitPointsMax = 12;

        level = 1;
        exp = 0;
        proficiencyBonus = 2 + (level - 1) / 4;
        characterName = "Player";
        weapon = new LongswordWeapon();
    }

    public override int DoDamageRoll()
    {
        int damageRoll = weapon.DoDamageRoll(strength.GetModifier());
        Debug.Log(characterName + " does " + damageRoll + " damage");
        return damageRoll;
    }
}