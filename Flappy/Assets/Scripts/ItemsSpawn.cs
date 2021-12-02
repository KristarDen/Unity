using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawn : MonoBehaviour
{
    GameObject Pixel_Egg;
    GameObject Bug;

    void Start()
    {
        Pixel_Egg = GameObject.Find("Egg-Pixel");
        Bug = GameObject.Find("Bug");

        Pixel_Egg.gameObject.SetActive(false);
        Bug.gameObject.SetActive(false);
    }


    void Update()
    {
        if(Pixel_Egg.gameObject.activeSelf == false)
        {
            float period = Random.Range(20f, 40f);
            Invoke("SpawnEgg", period);
        }
        if (Bug.gameObject.activeSelf == false)
        {
            float period = Random.Range(10f, 20f);
            Invoke("SpawnBug", period);
        }
        transform.Translate(Vector2.left * 2 * Time.deltaTime);
    }

    void SpawnEgg()
    {
        Pixel_Egg.SetActive(true);
        GameObject SpawnZone = RandomSpawnZone();

        float x = 0, y = 0;

        x = SpawnZone.transform.position.x + Random.Range(-2f, 2f);
        y = SpawnZone.transform.position.y + Random.Range(-4f, 4f);

        Pixel_Egg.transform.position = new Vector3(x, y, 0f);
    }

    void SpawnBug()
    {
        Bug.SetActive(true);
        GameObject SpawnZone = RandomSpawnZone();

        float x = 0, y = 0;

        x = SpawnZone.transform.position.x + Random.Range(-2f, 2f);
        y = SpawnZone.transform.position.y + Random.Range(-4f, 4f);

        Bug.transform.position = new Vector3(x, y, 0f);
    }

    GameObject RandomSpawnZone()
    {
        return this.gameObject;
    }
}
