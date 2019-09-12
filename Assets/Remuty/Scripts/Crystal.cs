using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    [SerializeField] GameObject[] monster;
    float interval = 2;
    public GameObject gauge;
    float hp;
    public Status status;
    // Start is called before the first frame update
    void Start()
    {
        hp = status.maxHp;
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
        GaugeDown(hp, status.maxHp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

	private void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Braver")
        {
            int braver_atk = c.gameObject.GetComponent<Braver>().status.atk;
            hp -= braver_atk * Time.deltaTime;
        }
    }
    void GaugeDown(float current, int max)
    {
        gauge.GetComponent<Image>().fillAmount = current / max;
    }
}
