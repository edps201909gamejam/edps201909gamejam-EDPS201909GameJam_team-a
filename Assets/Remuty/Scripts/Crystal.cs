using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] GameObject[] monster;
    float interval = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;
        if (interval <= 0)
        {
            int m = Random.Range(0,monster.Length);
            Instantiate(monster[m], transform.position, Quaternion.identity);
            interval = 2;
        }
    }
}
