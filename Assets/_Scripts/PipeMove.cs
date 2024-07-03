using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //goi dua tren FPS: Time.deltaTime = 1 / FPS;
    {
        MovePipe();
    }

    private void MovePipe()
    {
        //Vector3: x, y, z
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -8)
        {
            Debug.Log("Ra khỏi màn hình ");
            Destroy(gameObject);
        }    
    }
}
