using UnityEngine;
using System;

public static class Rng_System
{
    private static System.Random randomGenerator;
    private static bool useSeededRandom = false;
    private static int currentSeed = 0;

    static void Start()
    {
        // Initialize with current time as default seed
        ResetRandomSeed();
    }

    // Update is called once per frame
    static void Update()
    {
        
    }

    /// <summary>
    /// Set a specific seed for deterministic random rolls
    /// </summary>
    static public void SetRandomSeed(int seed)
    {
        currentSeed = seed;
        randomGenerator = new System.Random(seed);
        useSeededRandom = true;
        Debug.Log($"RNG seed set to: {seed}");
    }

    /// <summary>
    /// Reset to a new random seed based on system time
    /// </summary>
    static public void ResetRandomSeed()
    {
        // Use current timestamp for a "random" seed
        currentSeed = Environment.TickCount;
        randomGenerator = new System.Random(currentSeed);
        Debug.Log($"RNG seed reset to: {currentSeed}");
    }

    /// <summary>
    /// Disable seeded random and use Unity's Random instead
    /// </summary>
    static public void UseUnityRandom()
    {
        useSeededRandom = false;
        Debug.Log("Using Unity's non-deterministic Random");
    }

    /// <summary>
    /// Get the current seed value being used
    /// </summary>
    static public int GetCurrentSeed()
    {
        return currentSeed;
    }

    /// <summary>
    /// Roll dice with specified parameters
    /// </summary>
    /// <param name="count">Number of dice to roll (default: 1)</param>
    /// <param name="sides">Number of sides per die</param>
    /// <param name="modifier">Bonus to add to total (default: 0)</param>
    /// <param name="advantage">Use advantage (roll twice, take higher)</param>
    /// <param name="disadvantage">Use disadvantage (roll twice, take lower)</param>
    /// <returns>Total of dice rolls plus modifier</returns>
    static public int RollDice(int sides, int count = 1, int modifier = 0, bool advantage = false, bool disadvantage = false)
    {
        int total = 0;

        // Handle advantage/disadvantage (only applies to first die)
        if (count > 0 && (advantage || disadvantage))
        {
            int roll1 = SingleDieRoll(sides);
            int roll2 = SingleDieRoll(sides);
            
            total += advantage ? Mathf.Max(roll1, roll2) : Mathf.Min(roll1, roll2);
            count--; // We've already rolled one die
        }
        
        // Roll remaining dice
        for (int i = 0; i < count; i++)
        {
            total += SingleDieRoll(sides);
        }

        // Add modifier
        return total + modifier;
    }

    /// <summary>
    /// Roll multiple dice and get individual results
    /// </summary>
    /// <param name="count">Number of dice to roll</param>
    /// <param name="sides">Number of sides per die</param>
    /// <returns>Array of individual die results</returns>
    static public int[] RollDiceIndividual(int sides, int count)
    {
        int[] results = new int[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = SingleDieRoll(sides);
        }
        return results;
    }

    /// <summary>
    /// Internal method for a single die roll
    /// </summary>
    static private int SingleDieRoll(int sides)
    {
        if (useSeededRandom)
            return randomGenerator.Next(1, sides + 1);
        else
            return UnityEngine.Random.Range(1, sides + 1);
    }
}