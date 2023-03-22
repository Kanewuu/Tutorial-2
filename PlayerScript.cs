using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;
    Animator anim;
    public Text score;
    public Text lives;
    private bool teleport = false;
    private int scoreValue = 0;
    private int livesValue = 3;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    void Update()

    {

    if (Input.GetKeyDown(KeyCode.D))
        {

          anim.SetInteger("State", 1);

         }
    if (Input.GetKeyUp(KeyCode.D))
        {

          anim.SetInteger("State", 0);

         }
    if (Input.GetKeyDown(KeyCode.A))

        {
          anim.SetInteger("State", 1);
         }
    if (Input.GetKeyUp(KeyCode.A))

        {
          anim.SetInteger("State", 0);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        lives.text = livesValue.ToString();
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if(scoreValue == 8)
        {
            winTextObject.SetActive(true);
        }

        if(livesValue == 0)
        {
            loseTextObject.SetActive(true);
            speed = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            lives.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
        }
        if(scoreValue == 4 && !teleport)
        {
            transform.position = new Vector2(85.0f, 0.5f);
            teleport = true;
            livesValue = 3;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 2), ForceMode2D.Impulse); 
            }
        }
    }
}
