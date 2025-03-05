public class LongswordWeapon : Weapon
{
    public LongswordWeapon()
    {
        attackRollCount = 1;
        attackRollDiceSize = 8;
    }

    public override int DoDamageRoll(int modifier)
    {
        var damage = Rng_System.RollDice(attackRollDiceSize, attackRollCount, modifier);
        return damage;
    }
}