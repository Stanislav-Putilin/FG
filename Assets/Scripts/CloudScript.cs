using UnityEngine;

public class CloudScript : MonoBehaviour
{
	private float speed;

	void Start()
	{
		speed = Random.Range(2.0f, 6.0f);
		this.transform.localScale = Vector3.one * Random.Range(0.2f,2.0f);
	}

	void Update()
	{
		this.transform.Translate(speed * Time.deltaTime * Vector2.left);
	}
}
