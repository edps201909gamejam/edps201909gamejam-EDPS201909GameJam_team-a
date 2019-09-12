using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    float skill_time = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skill_time -= Time.deltaTime;
		if(skill_time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
