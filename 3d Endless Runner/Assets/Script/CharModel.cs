using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharModel
{
    public CharModel(PlayerScriptableObject playerScriptableObject)
    {
        speed = playerScriptableObject.speed;
        rb = playerScriptableObject.rb;
        turnSpeed = playerScriptableObject.turnSpeed;
        jumpforce = playerScriptableObject.jumpforce;
        jetPackForce = playerScriptableObject.jetPackForce;
        addScore = playerScriptableObject.addScore;
        playerGameObject = playerScriptableObject.playerGameObject;
    }

    public float speed;

    public Rigidbody rb { get; }

    public float turnSpeed { get; }

    public float jumpforce { get; }

    public float jetPackForce { get; }

    public int addScore { get; }

    public GameObject playerGameObject { get; }
}
