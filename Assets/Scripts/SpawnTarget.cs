using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int i = Random.Range(0, targets.Count);
        targets[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
