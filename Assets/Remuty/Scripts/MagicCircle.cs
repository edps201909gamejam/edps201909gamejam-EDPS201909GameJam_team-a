using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [SerializeField] GameObject crystal;
    bool create_crystal = false;
    float charge = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charge <= 0)
        {
            Instantiate(crystal, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

	void OnTriggerStay(Collider c)
    {
        if (c.tag == "Mao")
        {
            charge -= Time.deltaTime;
        }
    }
}
