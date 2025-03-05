using UnityEngine;
public abstract class Weapon
{
    public int attackRollCount;
    public int attackRollDiceSize;

    public virtual int AttackForDamage(int modifier)
    {
        return 0;
    }
}