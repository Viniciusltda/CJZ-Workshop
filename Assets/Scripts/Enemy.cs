using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float timeLimit;
    private float time;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = new Vector2(speed, _rb.velocity.y);

    }

    private void Update() {
        time += Time.deltaTime;

    }


    void FixedUpdate()
    {   
        if(time >= timeLimit){
            speed = -speed;

            time = 0f;

        }

        _rb.velocity = new Vector2(speed, _rb.velocity.y);


        if(_rb.velocity.x > 0){
            transform.eulerAngles = new Vector2(0f, 180f);

        }else {
            transform.eulerAngles = new Vector2(0f, 0f);

        }


    }
}
