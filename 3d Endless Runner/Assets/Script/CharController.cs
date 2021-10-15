using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharController 
{
    private GameObject player;

    private Rigidbody rb;

    public CharController(CharModel _charModel, TextMeshProUGUI scoreText, TextMeshProUGUI jetPackActivated, Joystick leftJoystick, Joystick rightJoystick, DebugMenu debugMenu)
    {
        charModel = _charModel;

        ScoreText = scoreText;

        JetPackActivated = jetPackActivated;

        LeftJoystick = leftJoystick;

        RightJoystick = rightJoystick;

        player = GameObject.Instantiate(charModel.playerGameObject);

        rb = player.GetComponent<Rigidbody>();

        characterMove = player.GetComponent<CharacterMove>();

        characterMove.SetCharController(this);

        debugMenu.SetCharacterMove(characterMove);
    }

    public void Velocity(Vector3 dir)
    {
        dir = new Vector3(charModel.turnSpeed * LeftJoystick.Horizontal, 0, charModel.speed);
        rb.velocity = dir;
    }

    public void SetScoreText(string _scoreText)
    {
        ScoreText.text = _scoreText;
    }

    public bool CheckJump(bool jetPack)
    {
        if ((RightJoystick.Vertical > 0) && (jetPack != true))
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
        return true;
    }

    public bool DeactivateJetPack()
    {
        JetPackActivated.gameObject.SetActive(false);
        return false;
    }

    public void SetSpeed(float _speed)
    {
        charModel.speed = _speed;
    }

    public void ImplementJetpack()
    {
        if (RightJoystick.Vertical > 0)
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

    public CharacterMove characterMove { get; }
    public CharModel charModel { get; }
    public TextMeshProUGUI ScoreText { get; }
    public TextMeshProUGUI JetPackActivated { get; }
    public Joystick LeftJoystick { get; }
    public Joystick RightJoystick { get; }
}
