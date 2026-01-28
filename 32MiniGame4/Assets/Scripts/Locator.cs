using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    //locator
    public static Locator instance { get; private set; }
    public Bird bird { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        GameObject birdObject = GameObject.FindWithTag("Player");
        bird = birdObject.GetComponent<Bird>();
    }
}
