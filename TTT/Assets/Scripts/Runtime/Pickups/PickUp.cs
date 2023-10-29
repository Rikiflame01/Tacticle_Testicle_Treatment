using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Pickup : MonoBehaviour
{
    public abstract void OnPickup(Player player);

    //void OnTriggerEnter(Collider other)
    //{
    //    Player player = other.GetComponent<Player>();
    //    if (player != null)
    //    {
    //        Debug.Log("Picked up by player!");
    //        OnPickup(player);
    //        Destroy(gameObject);
    //    }
    //}\
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.itemPickup, 3);
            Player player = collision.gameObject.GetComponent<Player>();
            OnPickup(player);
            Destroy(gameObject);
        }
    }
}