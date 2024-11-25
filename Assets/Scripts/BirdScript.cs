using System.Linq;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
	public static int score;
    private Rigidbody2D rb2d;
    void Start()
    {
		score = 0;
		colliders = this.GetComponents<Collider2D>();
		rb2d = GetComponent<Rigidbody2D>();
	}
   
    void Update()
    {
		if (Time.timeScale == 0.0f) return;

		if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * 300);			
		}

        this.transform.eulerAngles = new Vector3(0, 0, 2.5f * rb2d.linearVelocityY);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if(collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Game Over");
        }

		Debug.Log(collision.gameObject.name);
	}
	private Collider2D[] colliders;
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Pipe"))
		{
			if (!colliders.Any(c => c.IsTouching(collision)))
			{
				score += 1;
			}
		}		
	}

	bool isOneTouch = true;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("LedyBug") && isOneTouch)
		{
			isOneTouch = false;
			DestroyInsect(collision);
			if (colliders[0])
			{
				score += 5;
			}

		}

		if (collision.gameObject.CompareTag("Moscito") && isOneTouch)
		{
			DestroyInsect(collision);
			if (colliders[0])
			{
				score += 3;
			}
		}
	}

	private void DestroyInsect(Collider2D collision)
	{
		Transform parentTransform = collision.gameObject.transform.parent;
		GameObject.Destroy(collision.gameObject);

		if (parentTransform != null)
		{
			GameObject.Destroy(parentTransform.gameObject);
		}
		isOneTouch = true;
	}
}
