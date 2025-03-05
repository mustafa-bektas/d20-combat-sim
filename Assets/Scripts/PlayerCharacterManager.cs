using System.Reflection;
using UnityEditor;
using UnityEngine;
public class PlayerCharacterManager : MonoBehaviour
{
    public Character playerCharacter;

    void Start()
    {
        InitializePlayerCharacter();
        playerCharacter.DoAttackRoll();

        GameObject attackRollButton = GameObject.Find("AttackRollButton");
        attackRollButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnAttackRollButtonClick);

        GameObject damageRollButton = GameObject.Find("DamageRollButton");
        damageRollButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnDamageRollClick);
    }

    private void OnAttackRollButtonClick()
    {
        // clear unity console
        ClearConsole();
        playerCharacter.DoAttackRoll();
    }

    private void OnDamageRollClick()
    {
        // clear unity console
        ClearConsole();
        playerCharacter.DoDamageRoll();
    }

    private void InitializePlayerCharacter()
    {
        GameObject fighterObject = new GameObject("Fighter");
        playerCharacter = fighterObject.AddComponent<FighterCharacter>();
        
        playerCharacter.InitializePlayerCharacter();
    }

    public static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}