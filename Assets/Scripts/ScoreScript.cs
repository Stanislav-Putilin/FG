using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI scoreTmp;
    void Start()
    {
		scoreTmp = GetComponent<TMPro.TextMeshProUGUI>();

	}

    // Update is called once per frame
    void Update()
    {
		scoreTmp.text = BirdScript.score.ToString();
	}
}
