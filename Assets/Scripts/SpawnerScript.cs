using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    private float pipeSpawnPeriod = 4.0f;
    private float pipeTimeout;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pipeTimeout = 0.0f;

	}

    // Update is called once per frame
    void Update()
    {
		pipeTimeout -= Time.deltaTime;
        if(pipeTimeout <= 0.0f)
        {
            SpawnPipe();
            pipeTimeout = pipeSpawnPeriod;
		}


	}

    private void SpawnPipe()
    {
        GameObject pipe = GameObject.Instantiate(pipePrefab);
		pipe.transform.position = this.transform.position + Random.Range(-2f,2f) * Vector3.up;
	}
}
