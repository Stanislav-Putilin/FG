using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;

	[SerializeField]
	private GameObject cloudPrefab;

	[SerializeField]
	private GameObject[] insectPrefab;

	private float pipeSpawnPeriod = 4.0f;
    private float pipeTimeout;

    private Vector3 randomPosition;
    
    
    void Start()
    {
        pipeTimeout = 0.0f;
	}
    
    void Update()
    {
		pipeTimeout -= Time.deltaTime;
        if (pipeTimeout <= 0.0f)
        {
            SpawnPipe();
            pipeTimeout = pipeSpawnPeriod;

            int chance = Random.Range(0, 3);
           
            if (chance > 1)
            {
                SpawnInsect();
            }

            if (chance > 0)
            {
                SpawnCloud();

			}
        }
	}

	private void SpawnCloud()
	{
		
		GameObject insect = GameObject.Instantiate(cloudPrefab);

		insect.transform.position = this.transform.position + Random.Range(3f, 5f) * Vector3.up;
	}

	private void SpawnInsect()
	{
        int randomIndex = Random.Range(0, insectPrefab.Length);
		GameObject insect = GameObject.Instantiate(insectPrefab[randomIndex]);

		insect.transform.position = randomPosition + Random.Range(-1.5f, 1.5f) * Vector3.up + Random.Range(-1.5f, 1.5f) * Vector3.right;
	}

	private void SpawnPipe()
    {
		GameObject pipe = GameObject.Instantiate(pipePrefab);
        randomPosition = this.transform.position + Random.Range(-2f, 2f) * Vector3.up;

		pipe.transform.position = randomPosition;       
	}
}
