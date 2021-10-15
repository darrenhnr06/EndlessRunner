using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterService : MonoBehaviour
{
    public PlayerScriptableObject playerScriptableObject;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI jetPackActivated;

    public Joystick leftJoystick;

    public Joystick rightJoystick;

    public DebugMenu debugMenu;

    void Start()
    {
        CreateNewPlayer();
    }

    void CreateNewPlayer()
    {
        CharModel charModel = new CharModel(playerScriptableObject);
        CharController charController = new CharController(charModel, scoreText, jetPackActivated, leftJoystick, rightJoystick, debugMenu);
    }
}
