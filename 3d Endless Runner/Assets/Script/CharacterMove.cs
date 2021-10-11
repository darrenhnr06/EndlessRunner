using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    public float speed = 100;
    public CharacterController characterController;
    public Rigidbody rb;
    private float turnSpeed = 10;
    public float jumpforce;
    private Vector3 dir;
    private bool jump;
    public TextMeshProUGUI scoreText;
    private int score;
    private bool jetPack;
    private bool countJetpack;
  

    private void Awake()
    {
        scoreText.text = "Score: 0";
        score = 0;
        jetPack = false;
        countJetpack = true;
        rb.useGravity = true;
        jump = false;
    }
    private void Start()
    {
        dir = new Vector3(turnSpeed * Input.GetAxisRaw("Horizontal"), 0, speed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)) && (jetPack!=true))
        {
            jump = true;
        }
        scoreText.text = "Score: " + score.ToString();

        if (jetPack == true)
        {
            ImplementJetpack();
        }
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
            jump = false;
            jetPack = true;
            StartCoroutine(JetPackTimer());
        }
    }

    void ImplementJetpack()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * 9000);
        }
    }

    IEnumerator JetPackTimer()
    {
        yield return new WaitForSeconds(10f);
        jetPack = false;
        countJetpack = false;
        jump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Time.timeScale = 0.7f;
    }

    private void FixedUpdate()
    {
        dir.x = turnSpeed * Input.GetAxisRaw("Horizontal");
        rb.velocity = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            score += 10;
            other.gameObject.SetActive(false);
        }
    }
}
