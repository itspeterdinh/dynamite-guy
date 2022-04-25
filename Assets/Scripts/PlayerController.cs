using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    public Animator animator;
    private Rigidbody2D rb;
    private bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, 0);
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float speed = 0.1f;

        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        animator.SetFloat("Speed", speed);

        if (Mathf.Abs(x) > Mathf.Abs(y))
            y = 0;
        else if (Mathf.Abs(y) > Mathf.Abs(x))
            x = 0;
        
        Vector2 movement = new Vector2(Mathf.Round(x), Mathf.Round(y)) * playerSpeed;

        rb.velocity = movement;
    }

    public void Killed() 
    {
        Destroy(gameObject);
        SceneManager.LoadScene(3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            hasKey = true;
        }

        if (collision.CompareTag("Mine"))
        {
            Killed();
        }

        if (collision.CompareTag("Door") && hasKey == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
