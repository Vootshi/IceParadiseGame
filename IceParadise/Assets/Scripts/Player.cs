using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
    public float speed = 7f;
    public Text liveScore;
    
    float screenWidth;
    float screenHalfWidth;
    float screenHalfHeight;

    
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;

        screenHalfHeight = Camera.main.aspect * Camera.main.orthographicSize * 1.89f - transform.localScale.y;

        screenWidth = Screen.width / 2;
        
        liveScore.transform.position = new Vector2(liveScore.transform.position.x, Camera.main.pixelHeight - 150f);
    }

    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 direction = input.normalized;
        Vector2 velocity = direction * speed;

        transform.Translate(velocity*Time.deltaTime);

        TouchControl();

        if (transform.position.x > screenHalfWidth)
        {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y); 
        }
        if (transform.position.x < -screenHalfWidth)
        {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }

        //if (transform.position.y > screenHalfHeight)
        //{
        //    transform.position = new Vector2(transform.position.x, screenHalfHeight);
        //}
        //if (transform.position.y < -screenHalfHeight)
        //{
        //    transform.position = new Vector2(transform.position.x, - screenHalfHeight);
        //}

        liveScore.text = ((int)Mathf.Lerp(1,40000,Time.timeSinceLevelLoad/400)).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Falling Block")
        {
            OnPlayerDeath?.Invoke();
            Destroy(gameObject);
            liveScore.text = " ";
        }
    }

    void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < screenWidth)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
