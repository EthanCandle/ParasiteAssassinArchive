using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> platforms;
    public GameObject wholePlatform;
    public int numberFound, waveSize;
    public float spawnDelay, zSize, xSize, ySize;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 2;


        }
    }

    public void RandomNumber(ref int number, int negNum, int posNum)
    {
        number = Random.Range(negNum, posNum);


    }

    public void PlatformSpawn()
    {
        RandomNumber(ref numberFound, 0, platforms.Count);

        int number = 0;
        Instantiate(platforms[numberFound], new Vector3(platforms[numberFound].transform.position.x + xSize, platforms[numberFound].transform.position.y + ySize, platforms[numberFound].transform.position.z + zSize), platforms[numberFound].transform.rotation);
        Instantiate(wholePlatform, new Vector3(wholePlatform.transform.position.x + xSize, wholePlatform.transform.position.y + ySize, wholePlatform.transform.position.z + zSize), wholePlatform.transform.rotation);

        for (int i = 0; i < platforms[numberFound].transform.childCount; i++)
        {
           
            number = i;
        }
     

        if (platforms[numberFound].transform.childCount > 0)
        {


            //   Debug.Log(platforms[numberFound].transform.GetChild(transform.childCount).position.z);
            AddToSpacingOfSpawner(platforms[numberFound].transform.GetChild(transform.childCount + number).gameObject);
            Instantiate(wholePlatform, new Vector3(wholePlatform.transform.position.x + xSize, wholePlatform.transform.position.y + ySize, wholePlatform.transform.position.z + zSize), wholePlatform.transform.rotation);

            //  zSize += platforms[numberFound].transform.GetChild(transform.childCount + number).position.z + (platforms[numberFound].transform.GetChild(transform.childCount + number).localScale.z / 2);
            //  xSize += platforms[numberFound].transform.GetChild(transform.childCount + number).position.x + (platforms[numberFound].transform.GetChild(transform.childCount + number).localScale.x / 2);
            //   ySize += platforms[numberFound].transform.GetChild(transform.childCount + number).position.y + (platforms[numberFound].transform.GetChild(transform.childCount + number).localScale.y / 2);
            Debug.Log(platforms[numberFound].transform.GetChild(transform.childCount + number).name);
            Debug.Log(number);
            return;
        }


      //  zSize += platforms[numberFound].transform.position.z + platforms[numberFound].transform.localScale.z / 2 ;
       
        //ySize += platforms[numberFound].transform.position.y + platforms[numberFound].transform.localScale.y / 2; ;
        AddToSpacingOfSpawner(platforms[numberFound]);
        Instantiate(wholePlatform, new Vector3(wholePlatform.transform.position.x + xSize, wholePlatform.transform.position.y + ySize, wholePlatform.transform.position.z + zSize), wholePlatform.transform.rotation);

    }

    public void AddToSpacingOfSpawner(GameObject platform)
    {
        zSize += platform.transform.position.z + platform.transform.localScale.z / 2;
       
        //ySize += platform.transform.position.y + platform.transform.localScale.y / 2; ;


    }

    public IEnumerator WaveSpawn()
    {
        for (int i = 0; i < waveSize; i++)
        {
            PlatformSpawn();
            yield return new WaitForSeconds(spawnDelay);


        }
    }

}
