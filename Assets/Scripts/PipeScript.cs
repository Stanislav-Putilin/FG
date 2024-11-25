using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private float speed = 1.5f;
    
    void Start()
    {
        
    }    

    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector2.left); 
    }
}
