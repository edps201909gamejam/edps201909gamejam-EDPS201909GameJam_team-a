using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    NavMeshAgent agent;
    private Animator animator;
    public float distance = 0.3f;                           //攻撃範囲
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] braver = GameObject.FindGameObjectsWithTag("Braver");        //Braverタグのついたオブジェクトを取得
        agent.destination = braver[0].transform.position;
        if (agent.remainingDistance < distance)                                     //勇者に接近したら攻撃
        {
            animator.SetBool("AttackFlag", true);
            var aim = braver[0].transform.position - this.transform.position;        //止まったままターゲットの方向を向く
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
        }
    }
}
