using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mao : MonoBehaviour
{
    bool stan = false;
    [SerializeField] float stan_time = 5;
    float stan_count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stan && stan_count > 0)
        {
            stan_count -= Time.deltaTime;
        }
        if(stan_count <= 0)
        {
            stan = false;
            GetComponent<Player>().enabled = true;
        }
    }

	private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Skill")
        {
            stan_count = stan_time;
            stan = true;
            GetComponent<Player>().enabled = false;
        }
    }
}
