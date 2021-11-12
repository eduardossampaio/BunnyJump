using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    [SerializeField] private float sizeX;
    [SerializeField] private float destroyOnX;
    [SerializeField] private float speed;

    private Rigidbody2D scenarioRb;
    void Start()
    {
        scenarioRb = GetComponent<Rigidbody2D>();
        scenarioRb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= destroyOnX)
        {
            Destroy(this.gameObject);
        }
    }

    public float GetSizeX()
    {
        return sizeX;
    }

    internal void Stop()
    {
        scenarioRb.velocity = new Vector2(0, 0);
    }
}
