using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int jumpf;
    private bool _canJump;


    private Rigidbody2D _rb;
    private Animator _anim;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

    }

    private void Update() {
        _Jump();

    }

    private void FixedUpdate() {
        _move();

        if(_rb.velocity.y < -10){
            _anim.SetBool("NotGrounded", true);

        }

    }

    private void _move(){
        float movex = Input.GetAxis("Horizontal");

        if (movex > 0f){
            transform.eulerAngles = new Vector2(0f, 0f);

        }else if (movex < 0f){
            transform.eulerAngles = new Vector2(0f, 180f);

        }

        _rb.velocity = new Vector2((movex * speed), _rb.velocity.y);

        if (_rb.velocity.x > 0f || _rb.velocity.x < 0f){
            _anim.SetBool("IsRunning", true);

        }else {
            _anim.SetBool("IsRunning", false);

        }


    }

    private void _Jump(){
        if(Input.GetButtonDown("Jump") && _canJump){
            _rb.AddForce(new Vector2(0f, jumpf), ForceMode2D.Impulse);

            _canJump = false;

            _anim.SetBool("IsJumping", true);
            _anim.SetBool("NotGrounded", true);

        }

        if(_rb.velocity.y < 0){
            _anim.SetBool("IsJumping", false);

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 8){
            _canJump = true;

            _anim.SetBool("NotGrounded", false);

            _anim.SetBool("IsJumping", false);

        }

        if(other.gameObject.CompareTag("Enemy")){


        } else if(other.gameObject.CompareTag("EnemyKill")){
            Destroy(other.transform.parent.gameObject);

        }
    }
}
