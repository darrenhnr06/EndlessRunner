using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterService : MonoBehaviour
{
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI jetPackActivated;

    [SerializeField]
    private DebugMenu debugMenu;

    [SerializeField]
    private Joystick joystick;

    void Start()
    {
        CreateNewPlayer();
    }

    void CreateNewPlayer()
    {
        CharModel charModel = new CharModel(playerScriptableObject);
        CharController charController = new CharController(charModel, scoreText, jetPackActivated, debugMenu, joystick);
    }
}
