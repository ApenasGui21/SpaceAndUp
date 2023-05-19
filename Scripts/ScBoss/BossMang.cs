using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMang : MonoBehaviour
{
    public GameObject Boss2;
    public GameObject Boss3;
    public static bool boss2 = false;
    public static bool boss3 = false;

    void Update()
    {
        if (boss2)
        {
            Instantiate(Boss2, new Vector3(0, 12, 0), Quaternion.identity).transform.parent = this.transform;
            boss2 = false;
        }
        if (boss3)
        {
            Instantiate(Boss3, new Vector3(0, -7.5f, 0), Quaternion.identity).transform.parent = this.transform;
            boss3 = false;
        }
    }
}
