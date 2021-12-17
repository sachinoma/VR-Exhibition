using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOController3 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D RD2D;
    public SpriteRenderer PlayerSr;

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
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            if (PlayerSr.flipX == true)
            {
                PlayerSr.flipX = false;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            if (PlayerSr.flipX == false)
            {
                PlayerSr.flipX = true;
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;//count ++ //count += 1
            SetCountText();
            Music.PlayOneShot(collect);
        }
    }

    void SetCountText()
    {
        countText.text = "星星數:" + count.ToString();
        if (count >= 10)
        {
            winText.text = "恭喜你找到了所有的星星！！";
            Time.timeScale = 0;
        }
    }
}
