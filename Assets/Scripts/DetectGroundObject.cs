using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGroundObject : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject player, slopeChecker;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
      //  offset = transform.position;


    }

    // Update is called once per frame
    void LateUpdate()
    {
      //   transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z );
        transform.position = player.transform.position + offset;
      //  transform.position = new Vector3(0, 0, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        slopeChecker.SetActive(true);
        pm.isGrounded = true;


     
    }

    private void OnCollisionExit(Collision collision)
    {

        pm.isGrounded = false;



    }


}
