using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CharacterMove : MonoBehaviour
{
    private Vector3 dir;

    private int score;

    private CharController charController;

    private bool jump;

    private bool jetPack;

    private bool countJetpack;

    private void Awake()
    {
        score = 0;
        jetPack = false;
        countJetpack = true;
        jump = false;
    }

    private void Start()
    {
        if(charController != null)
        {
            charController.SetScoreText("Score: 0");
        }
    }

    public void SetCharController(CharController _charController)
    {
        charController = _charController;
    }

    private void Update()
    {
        if (charController != null)
        {
            jump = charController.CheckJump(jetPack);

            charController.SetScoreText("Score: " + score.ToString());

            if (jetPack == true)
            {
                charController.ImplementJetpack();
            }
        }
    }

    public void SetSpeed(float _speed)
    {
        if (charController != null)
        {
            charController.SetSpeed(_speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 1;

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("FallCollide"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (charController != null)
        {
            if (jump == true)
            {
                jump = charController.ImplementJump();
            }

            if ((score > 100) && (jetPack == false) && (countJetpack == true))
            {
                jetPack = charController.ActivateJetPack();
                jump = false;
                StartCoroutine(JetPackTimer());
            }
        }
    }

    IEnumerator JetPackTimer()
    {
        yield return new WaitForSeconds(10f);

        if (charController != null)
        {
            jetPack = charController.DeactivateJetPack();
            countJetpack = false;
            jump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Time.timeScale = 0.7f;
    }

    private void FixedUpdate()
    {
        if (charController != null)
        {
            charController.Velocity(dir);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            if (charController != null)
            {
                score = charController.UpdateScore(score, other);
            }
        }
    }
}
