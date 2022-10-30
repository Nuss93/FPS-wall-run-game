using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private CharacterController _enemyAI;
    private PlayerController _playerScript;

    public float speed = 6f;
    public float _gravity = 9.8f;
    public float _gravityValue = 9.8f;
    public float _gravityMultiplier = 1f;
    private float _enemiesYVelocity;

    
    void Start()
    {
        // Get player game object
        _enemyAI = GetComponent<CharacterController>();
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (_enemyAI == null)
            Debug.LogError("Enemy AI script null");
        if (_playerScript == null)
            Debug.LogError("Player script null");
    }

    void Update()
    {
        // Declare the movement variables for the enemy
        Vector3 direction = _playerScript.transform.position - transform.position;
        Vector3 velocity = direction * speed;
        float _gravity = _gravityValue * _gravityMultiplier * Time.deltaTime;

        // Ensure enemy doesnt fly when player is grappling
        if(_enemyAI.isGrounded)
        {

        }
        else
        {
            _enemiesYVelocity -= _gravity;
        }
        velocity.y = _enemiesYVelocity;
        velocity.Normalize();

        // Rotate the enemy to face the player at all times
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), speed * Time.deltaTime);

        // Move the enemy
        _enemyAI.Move(velocity * Time.deltaTime);
    }
}
