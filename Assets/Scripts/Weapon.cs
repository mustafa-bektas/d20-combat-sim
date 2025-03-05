using UnityEngine;
public abstract class Weapon
{
    public int attackRollCount;
    public int attackRollDiceSize;

    public virtual int DoDamageRoll(int modifier)
    {
        return 0;
    }
}