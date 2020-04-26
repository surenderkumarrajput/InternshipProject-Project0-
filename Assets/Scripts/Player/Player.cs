using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Rigidbody2D Player_RigidBody;

    private float Input_Horizontal;

    public int Coin_Count=0;

    public float Speed;
    public float JumpForce;

    private bool canJump;

    void Start()
    {
        Player_RigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checking IsGorunded or not
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    //Checking IsGorunded or not
    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking on collision with end point game is over
        if (collision.CompareTag("End"))
        {
            SceneManager.LoadScene("End");
        }
        //Checking Whether it Hit Coin
        if(collision.CompareTag("Coins"))
        {
            Coin_Count++;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        //Taking Horizontal Movement Input
        Input_Horizontal = Input.GetAxisRaw("Horizontal") * Speed;

        //Taking Jump Input
        if(Input.GetKeyDown(KeyCode.Space)&&canJump)
        {
            Player_RigidBody.AddForce(new Vector2(0f,JumpForce));
        }
    }
    private void LateUpdate()
    {
        //Triggering Movement
        transform.Translate(new Vector2(Input_Horizontal, Player_RigidBody.velocity.y) * Time.deltaTime);
    }
}
