using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpCount : MonoBehaviour
{
    int mp = 0;
    public int circle_count;
    int crystal_count = 0;
    bool skill_use = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mp);
        GameObject[] magic_circle = GameObject.FindGameObjectsWithTag("MagicCircle");
        if (magic_circle.Length == circle_count - 1)
        {
            circle_count--;
            crystal_count++;
        }
        GameObject[] crystal = GameObject.FindGameObjectsWithTag("Crystal");
        if (crystal.Length == crystal_count -1)
        {
            crystal_count--;
            mp++;
        }
        GameObject[] skill = GameObject.FindGameObjectsWithTag("Skill");
        if (skill.Length > 0 && !skill_use)
        {
            skill_use = true;
            mp--;
        }
        if (skill.Length == 0)
        {
            skill_use = false;
        }
    }

	public int GetMp()
    {
        return mp;
    }
}
