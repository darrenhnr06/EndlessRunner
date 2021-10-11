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
    private CharacterMove character;

    [SerializeField]
    private Button saveButton;

    [SerializeField]
    private TMP_Dropdown cameraOption;

    [SerializeField]
    private Camera backCamera;

    [SerializeField]
    private Camera topCamera;

    [SerializeField]
    private TMP_Dropdown obstacleOption;

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
