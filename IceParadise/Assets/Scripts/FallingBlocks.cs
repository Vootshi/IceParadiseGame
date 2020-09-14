using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 speedMinMax;

    float visibleHeightThreshold;

    private void Start()
    {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }

    
}
