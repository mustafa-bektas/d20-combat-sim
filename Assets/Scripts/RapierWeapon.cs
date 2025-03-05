public class RapierWeapon : Weapon
{
    public RapierWeapon()
    {
        attackRollCount = 1;
        attackRollDiceSize = 8;
    }

    public override int AttackForDamage(int modifier)
    {
        var damage = Rng_System.RollDice(attackRollDiceSize, attackRollCount, modifier);
        return damage;
    }
}