using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitFit : MonoBehaviour
{
    public GameObject playerBig, playerSmall;
    public ChangePlayer cp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fit"))
        {
            cp.ChangeToSmall();
        }
        // for the big guy to turn small
    }
}
 