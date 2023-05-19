using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escudoBoss : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tiroPC"))
        {
            Destroy(other.gameObject);
        }
    }
}
