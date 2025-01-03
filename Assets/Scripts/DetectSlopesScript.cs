using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSlopesScript : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        //  offset = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        //   transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z );
        transform.position = player.transform.position + offset;
        //  transform.position = new Vector3(0, 0, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        pm.OnSlope();

       // Debug.Log("OnGround");

    } 
    private void OnCollisionEnter(Collision collision)
    {
        pm.OnSlope();

        Debug.Log("OnGround");

    }
      private void OnCollisionExit(Collision collision)
    {
        pm.NotOnSlope();

        Debug.Log("OnGround");

    }

   
}
