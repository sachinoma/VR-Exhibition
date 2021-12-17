using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOController4 : MonoBehaviour
{
    public SpriteRenderer PlayerSr;

    private Rigidbody2D RD2D;

    public Text countText;//吃到幾個黃金
    public Text winText;//你贏了
    private int count;

    public AudioClip collect;
    private AudioSource Music;

    // Start is called before the first frame update
    void Start()
    {
        RD2D = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        Music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0.3f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -0.3f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (PlayerSr.flipX == true)
            {
                PlayerSr.flipX = false;
            }
            transform.Translate(-0.3f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (PlayerSr.flipX == true)
            {
                PlayerSr.flipX = false;
            }
            transform.Translate(0.3f, 0, 0);

        }
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup")) 
        {
            collision.gameObject.SetActive(false);
            count = count + 1;//count ++ //count += 1
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 10)
            winText.text = "You Win";
    }
}
