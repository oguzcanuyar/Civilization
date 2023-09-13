using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bot")
        {
            other.gameObject.GetComponent<Bot>().SellWoods();
        }
    }
}
