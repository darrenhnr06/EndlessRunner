using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public float speed;

    public Rigidbody rb;

    public float turnSpeed;

    public float jumpforce;

    public float jetPackForce;

    public int addScore;

    public GameObject playerGameObject;
}
