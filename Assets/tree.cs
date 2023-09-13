using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public Forest _forest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bot")
        {
            other.gameObject.GetComponent<Bot>().CutTree();
            _forest.Trees.Remove(this);
            Destroy(gameObject);
        }
    }
}
