using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class BirdMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float jumpForce = 0f;
    private bool levelStart;

    public GameObject gameController;

    private int score;
    public TextMeshProUGUI scoreText;

    public GameObject message;


    private void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        rigidbody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //kiem tra xem phim Space co duoc bam khong ?
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SoundController.instance.PlayThisSound("wing", 0.5f);
            if (levelStart == false)
            {
                levelStart = true;
                rigidbody.gravityScale = 6;
                gameController.GetComponent<PipeGenerator>().enableGeneratePipe = true;
               
                message.GetComponent<SpriteRenderer>().enabled = false;
            }
            BirdMoveUp();

        }
    }

    private void BirdMoveUp()
    {
        rigidbody.velocity = Vector3.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Va cham !");
        SoundController.instance.PlayThisSound("hit", 0.5f);
        ReloadScene();
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
        SoundController.instance.PlayThisSound("point", 0.5f);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
        score = 0;
    }
}
