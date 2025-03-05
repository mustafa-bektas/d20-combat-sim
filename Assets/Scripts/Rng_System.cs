using UnityEngine;
using System;

public class Rng_System : MonoBehaviour
{
    private System.Random randomGenerator;
    private bool useSeededRandom = false;
    private int currentSeed = 0;

    void Start()
    {
        // Initialize with current time as default seed
        ResetRandomSeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Set a specific seed for deterministic random rolls
    /// </summary>
    public void SetRandomSeed(int seed)
    {
        currentSeed = seed;
        randomGenerator = new System.Random(seed);
        useSeededRandom = true;
        Debug.Log($"RNG seed set to: {seed}");
    }

    /// <summary>
    /// Reset to a new random seed based on system time
    /// </summary>
    public void ResetRandomSeed()
    {
        // Use current timestamp for a "random" seed
        currentSeed = Environment.TickCount;
        randomGenerator = new System.Random(currentSeed);
        Debug.Log($"RNG seed reset to: {currentSeed}");
    }

    /// <summary>
    /// Disable seeded random and use Unity's Random instead
    /// </summary>
    public void UseUnityRandom()
    {
        useSeededRandom = false;
        Debug.Log("Using Unity's non-deterministic Random");
    }

    /// <summary>
    /// Get the current seed value being used
    /// </summary>
    public int GetCurrentSeed()
    {
        return currentSeed;
    }

    private int RollDice(int sides)
    {
        if (useSeededRandom)
            return randomGenerator.Next(1, sides + 1);
        else
            return UnityEngine.Random.Range(1, sides + 1);
    }

    private int RollWithAdvantage(int sides)
    {
        int roll1 = RollDice(sides);
        int roll2 = RollDice(sides);
        return Mathf.Max(roll1, roll2);
    }

    private int RollWithDisadvantage(int sides)
    {
        int roll1 = RollDice(sides);
        int roll2 = RollDice(sides);
        return Mathf.Min(roll1, roll2);
    }

    private int RollWithModifier(int sides, int modifier)
    {
        return RollDice(sides) + modifier;
    }

    private int RollWithAdvantageAndModifier(int sides, int modifier)
    {
        return RollWithAdvantage(sides) + modifier;
    }

    private int RollWithDisadvantageAndModifier(int sides, int modifier)
    {
        return RollWithDisadvantage(sides) + modifier;
    }
}