using UnityEngine;

public class AbilityScore
{
    private int score;
    private int modifier;

    public void SetScore(int newScore)
    {
        score = newScore;
        CalculateModifier();
    }

    private void CalculateModifier()
    {
        modifier = Mathf.FloorToInt((score - 10) / 2f);
    }

    public int GetScore()
    {
        return score;
    }

    public int GetModifier()
    {
        return modifier;
    }
}