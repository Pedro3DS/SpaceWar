using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    [SerializeField] private float secondSpawn = 0.5f;

    [SerializeField] private float minTras;

    [SerializeField] private float maxTras;

    Vector3 spawnPosition;

    float[] randomAsteroidVelocity = { 50f, 100f, 150f };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    private void Update()
    {
        // get the main camera
        UnityEngine.Camera camera = UnityEngine.Camera.main;

        // get the world position of a screenspace point
        spawnPosition = camera.ScreenToWorldPoint(new Vector3(UnityEngine.Camera.main.pixelWidth + (gameObject.transform.localScale.x * 10), Screen.height / 2 , camera.nearClipPlane));

        // set the hero's position
        gameObject.transform.position = spawnPosition;

        Debug.Log(UnityEngine.Camera.main.pixelWidth);

        //// get the sprite from resources
        //heroSprite = Resources.Load<Sprite>("Sprites/heroImage");

        //// get a reference to the hero's SpriteRenderer
        //SpriteRenderer heroRenderer = hero.GetComponent<SpriteRenderer>();
        //// set the renderer's sprite
        //heroRenderer.sprite = heroSprite;
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
