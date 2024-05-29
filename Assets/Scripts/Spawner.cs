using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    [SerializeField] private float secondSpawn = 0.5f;

    [SerializeField] private float minTras;

    [SerializeField] private float maxTras;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FruitSpawn());
    }


    IEnumerator FruitSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var pos = new Vector3(transform.position.x, wanted);
            GameObject gameObjects = Instantiate(objects[Random.Range(0, objects.Length)], pos, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            //Destroy(gameObject, 5f);
        }
    }
}
