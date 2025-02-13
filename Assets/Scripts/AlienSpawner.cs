using System.Collections;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField] float maxX; //max position where we can spawn our aliens
    public GameObject[] Aliens;
    [SerializeField] float spawnInterval;
    public static AlienSpawner instance; //public static instance of AlienSpawner class. to be able to access any func of this code

    private void Awake(){
        if(instance == null){
            instance = this; //if public static instance is null set it to this
        }
    }

    void Start()
    {
        StartSpawnAlien();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAlien(){
        int randomSpawn = Random.Range(0, Aliens.Length);

        float randomX = Random.Range(-maxX, maxX); //generate random num (-maxX to maxX) and storing in randomX
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z); //generate V3 rand pos where x pos is randomized (y,z stay same)

        Instantiate(Aliens[randomSpawn], randomPos, transform.rotation); //instantiate alien in randomPos
    }

    IEnumerator SpawnAliens(){
        yield return new WaitForSeconds(2f);

        while (true){
            SpawnAlien();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawnAlien(){
        StartCoroutine("SpawnAliens");
    }

    public void StopSpawnAlien(){
        StopCoroutine("SpawnAliens");
    }
}
