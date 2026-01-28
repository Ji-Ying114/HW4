using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected Collider2D obstacleCollider;
    [SerializeField] protected Transform obstacleTransform;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float Xscale = 5f;
    [SerializeField] protected float Yscale = 20f;

    protected virtual void Start()
    {
        obstacleTransform.localScale = new Vector3(Xscale, Yscale, 1f);
    }
    protected virtual void Update()
    {
        obstacleTransform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
    public void StopMovement()
    {
        moveSpeed = 0f;
    }
}
