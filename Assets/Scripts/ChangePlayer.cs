using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public GameObject playerBig, playerSmall;
    public GameObject bCam, sCam; 
    public PlayerMovement sPM, bPM;
    public CountdownPlayer cdp;
    public float IncY;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
}

    public void ChangeToBig(GameObject objectHit)
    {
        playerBig.transform.position = playerSmall.transform.position;
        playerBig.transform.rotation = objectHit.transform.rotation;
        playerBig.transform.position = new Vector3(playerBig.transform.position.x, 0, playerBig.transform.position.z);
        bCam.transform.rotation = objectHit.transform.rotation;
        playerBig.SetActive(true);
        
        playerSmall.SetActive(false);

        cdp.ResetTimer(); // this turns on the timer
    }

    public void ChangeToSmall()
    {
        playerSmall.transform.position = playerBig.transform.position;
        playerSmall.transform.rotation = playerBig.transform.rotation;
        playerSmall.transform.position = new Vector3(playerSmall.transform.position.x, playerSmall.transform.position.y + IncY, playerSmall.transform.position.z);
        sCam.transform.rotation = bCam.transform.rotation;
        Debug.Log(sCam.transform.rotation);
        Debug.Log(bCam.transform.rotation);
        playerSmall.SetActive(true);
       
        playerBig.SetActive(false);
        sPM.Jump();
    }

    public void Win()
    {
        gm.Win();
    }
     public void Lose()
    {
        gm.Lose();
    }


}
