using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugMenu : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private Image menuImage;

    [SerializeField]
    private TMP_InputField speedInput;

    [SerializeField]
    private Button saveButton;

    [SerializeField]
    private TMP_Dropdown cameraOption;

    [SerializeField]
    private TMP_Dropdown obstacleOption;

    private CharacterMove characterMove;

    private GameObject backCamera;

    private GameObject topCamera;

    private string speedInputText;


    private void Awake()
    {
        button.onClick.AddListener(LoadMenu);
        saveButton.onClick.AddListener(CloseMenu);
        speedInputText = "6";
    }
  
    public void SetCharacterMove(CharacterMove _characterMove)
    {
        characterMove = _characterMove;
        backCamera = characterMove.gameObject.transform.GetChild(0).gameObject;
        topCamera = characterMove.gameObject.transform.GetChild(1).gameObject;
    }

    void LoadMenu()
    {
        if(characterMove != null)
        {
            characterMove.SetSpeed(0f);
        }
        
        menuImage.gameObject.SetActive(true);
        speedInput.text = speedInputText;
    }

    void CloseMenu()
    {
        if (characterMove != null)
        {
            characterMove.SetSpeed(float.Parse(speedInput.text));
        }
            
        if (cameraOption.value == 0)
        {
            backCamera.gameObject.SetActive(true);
            topCamera.gameObject.SetActive(false);
        }
        else
        {
            backCamera.gameObject.SetActive(false);
            topCamera.gameObject.SetActive(true);
        }

        PlayerPrefs.SetInt("Obstacle", obstacleOption.value);

        menuImage.gameObject.SetActive(false);
    }
}
