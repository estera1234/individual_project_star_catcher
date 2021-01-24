using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    public AudioClip pickupClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        AlienController controller = other.GetComponent<AlienController>();

        if (controller != null)
        {
            controller.ChangeScore(1);
            Destroy(gameObject);

            controller.PlaySound(pickupClip);
        }
    }
}

