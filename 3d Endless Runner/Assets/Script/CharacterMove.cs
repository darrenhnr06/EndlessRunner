using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody rb;

    private float turnSpeed;

    [SerializeField]
    private float jumpforce;

    private Vector3 dir;

    private bool jump;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score;

    private bool jetPack;

    private bool countJetpack;

    [SerializeField]
    private TextMeshProUGUI jetPackActivated;

    [SerializeField]
    private Joystick leftJoystick;

    [SerializeField]
    private Joystick rightJoystick;

    private float jetPackForce;

    private int addScore;

    private void Awake()
    {
        addScore = 10;
        turnSpeed = 10;
        scoreText.text = "Score: 0";
        score = 0;
        jetPack = false;
        countJetpack = true;
        rb.useGravity = true;
        jump = false;
        jetPackForce = 9000;
    }
    private void Start()
    {
        dir = new Vector3(turnSpeed * leftJoystick.Horizontal, 0, speed);
    }

    private void Update()
    {
        if ((rightJoystick.Vertical > 0) && (jetPack!=true))
        {
            jump = true;
        }
        scoreText.text = "Score: " + score.ToString();

        if (jetPack == true)
        {
            ImplementJetpack();
        }
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 1;

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(jump == true)
        {
            rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
            jump = false;
        }

        if ((score > 100) && (jetPack == false) && (countJetpack == true))
        {
            jetPackActivated.gameObject.SetActive(true);
            jump = false;
            jetPack = true;
            StartCoroutine(JetPackTimer());
        }
    }

    void ImplementJetpack()
    {
        if (rightJoystick.Vertical > 0)
        {
            rb.AddForce(Vector3.up * jetPackForce);
        }
    }

    IEnumerator JetPackTimer()
    {
        yield return new WaitForSeconds(10f);
        jetPack = false;
        countJetpack = false;
        jetPackActivated.gameObject.SetActive(false);
        jump = true;
        jetPackActivated.gameObject.SetActive(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        Time.timeScale = 0.7f;
    }

    private void FixedUpdate()
    {
        dir.z = speed;
        dir.x = turnSpeed * leftJoystick.Horizontal;
        rb.velocity = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            score += addScore;
            other.gameObject.SetActive(false);
        }
    }
}
