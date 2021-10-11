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

    private void Awake()
    {
        scoreText.text = "Score: 0";
        score = 0;
    }
    private void Start()
    {
        dir = new Vector3(turnSpeed * Input.GetAxisRaw("Horizontal"), 0, speed);
        rb.useGravity = true;
        jump = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
        {
            jump = true;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
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
    }

    private void OnCollisionExit(Collision collision)
    {
        
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
