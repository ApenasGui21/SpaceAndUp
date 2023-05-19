using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDestroi : MonoBehaviour
{
    public bool forte = false;

    public GameObject meteoroPequeno;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("tiro"))
        {
            if (forte)
            {
                Instantiate(meteoroPequeno, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), Quaternion.identity);
            }
            Destroy (this.gameObject);
        }
    }
}
