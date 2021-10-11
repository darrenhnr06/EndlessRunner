using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DebugMenu : MonoBehaviour
{
    public Button button;
    public Image menuImage;
    public TMP_InputField speedInput;
    public CharacterMove character;
    public Button saveButton;
    public TMP_Dropdown cameraOption;
    public Camera backCamera;
    public Camera topCamera;
    public TMP_Dropdown obstacleOption;

    private void Awake()
    {
        button.onClick.AddListener(LoadMenu);
        saveButton.onClick.AddListener(CloseMenu);
    }

    void LoadMenu()
    {
        character.SetSpeed(0f);
        menuImage.gameObject.SetActive(true);
        speedInput.text = "8";
    }

    void CloseMenu()
    {
        character.SetSpeed(float.Parse(speedInput.text));

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
