using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharController 
{
    private GameObject player;

    private Rigidbody rb;

    private int swipeHorizontal;

    
    public CharController(CharModel _charModel, TextMeshProUGUI scoreText, TextMeshProUGUI jetPackActivated, DebugMenu debugMenu, Joystick _joystick)
    {
        charModel = _charModel;

        ScoreText = scoreText;

        JetPackActivated = jetPackActivated;

        player = GameObject.Instantiate(charModel.playerGameObject);

        rb = player.GetComponent<Rigidbody>();

        characterMove = player.GetComponent<CharacterMove>();

        characterMove.SetCharController(this);

        debugMenu.SetCharacterMove(characterMove);

        joystick = _joystick;
    }

    public void SetSwipeHorizontal()
    {
        if(SwipeManager.swipeLeft)
        {
            swipeHorizontal = -1;
        }

        else if(SwipeManager.swipeRight)
        {
            swipeHorizontal = 1;
        }

        else
        {
            swipeHorizontal = 0;
        }
    }

    public void Velocity(Vector3 dir)
    {
        SetSwipeHorizontal();
        dir = new Vector3(charModel.turnSpeed * swipeHorizontal, 0, charModel.speed);
        rb.velocity = dir;
    }

    public void SetScoreText(string _scoreText)
    {
        ScoreText.text = _scoreText;
    }

    public bool CheckJump(bool jetPack)
    {
        if ((SwipeManager.swipeUp) && (jetPack != true))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ActivateJetPack()
    {
        JetPackActivated.gameObject.SetActive(true);
        joystick.gameObject.SetActive(true);
        return true;
    }

    public bool DeactivateJetPack()
    {
        JetPackActivated.gameObject.SetActive(false);
        joystick.gameObject.SetActive(false);
        return false;
    }

    public void SetSpeed(float _speed)
    {
        charModel.speed = _speed;
    }

    public void ImplementJetpack()
    {
        if (joystick.Vertical > 0)
        {
            rb.AddForce(Vector3.up * charModel.jetPackForce);
        }
    }

    public bool ImplementJump()
    {
        rb.AddForce(player.transform.up * charModel.jumpforce, ForceMode.Impulse);
        return false;
    }

    public int UpdateScore(int score, Collider other)
    {
        score += charModel.addScore;
        other.gameObject.SetActive(false);
        return score;
    }

    public Joystick joystick { get; }
    public CharacterMove characterMove { get; }
    public CharModel charModel { get; }
    public TextMeshProUGUI ScoreText { get; }
    public TextMeshProUGUI JetPackActivated { get; }
}
