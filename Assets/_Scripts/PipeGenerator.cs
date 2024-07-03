using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;
    //instantiate

    private float countDown;
    public float timeDuration;
    public bool enableGeneratePipe;

    // Start is called before the first frame update
    void Start()
    {
        countDown = 1f;
        enableGeneratePipe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableGeneratePipe)
        {
            countDown -= Time.deltaTime;//moi frame countdown -= 1/ FPS
                                        //30FPS moi frame countdown gam di 1/30s, moi giay (30 frames) thi countdown giam di dung 1
            if (countDown <= 0)
            {
                //Sinh ra ong
                Instantiate(pipePrefab, new Vector3(10, Random.Range(-1.2f, 2.1f), 0), Quaternion.identity);
                countDown = timeDuration;
            }

           
        }
     
    }
}
