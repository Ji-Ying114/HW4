using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BirdFlap();
public delegate void BirdCollision();
public delegate void ScoreEarned();

public class Bird : MonoBehaviour
{
    [SerializeField] private float flapStrength = 10f;
    [SerializeField] private Collider2D birdCollider;
    [SerializeField] private Transform birdTransform;
    [SerializeField] private float spawnXPosition = -5f;
    [SerializeField] private float spawnYPosition = 0f;
    //[SerializeField] private float gforce = -9.8f;
    [SerializeField] private Rigidbody2D birdRigidbody;
    
    public event BirdFlap OnBirdFlap;
    public event BirdCollision OnBirdCollision;
    public event ScoreEarned OnScoreEarned;
    private bool isAlive = true;

     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Obstacle")
         {
            OnBirdCollision?.Invoke();
            Die();
         }
    }
    private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.tag == "Score")
        {
            OnScoreEarned?.Invoke();
        }
     }

    void Start()
    {
        birdTransform.position = new Vector3(spawnXPosition, spawnYPosition, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            Flap();
            OnBirdFlap?.Invoke();
        }
    }

    private void Flap()
    {
        birdRigidbody.velocity = Vector2.up * flapStrength;
    }

    public float getResetX()
    {
        return spawnXPosition;
    }

    private void Die()
    {
        isAlive = false;
    }
}
