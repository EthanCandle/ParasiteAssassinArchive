using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitCit : MonoBehaviour
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
        if(other.CompareTag("Cit"))
        {
            Destroy(other.gameObject);
            cp.ChangeToBig(other.gameObject);
        }
        
        if(other.CompareTag("Win"))
        {
            cp.Win();
        }
        // turn small guy to big guy
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            cp.Lose();
        }
    }


}
