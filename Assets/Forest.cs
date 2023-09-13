using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public float TreeTimer;
    private float t = 0;
    public List<tree> Trees;
    [SerializeField] private GameObject TreePrefab;
    [SerializeField] private Transform MinX, MaxX;

    private void Update()
    {
        t += Time.deltaTime;
        if(t>= TreeTimer)
        {
            CreateTree();
            t = 0;
        }
    }

    private void CreateTree()
    {
        tree tre = Instantiate(TreePrefab,transform).GetComponent<tree>();
        tre._forest = this;
        tre.transform.position = new Vector3(UnityEngine.Random.Range(MinX.position.x,MaxX.position.x),tre.transform.position.y,UnityEngine.Random.Range(MinX.transform.position.z,MaxX.transform.position.z));
        Trees.Add(tre);
    }
}
