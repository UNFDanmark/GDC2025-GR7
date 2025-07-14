using UnityEngine;

public class HitMarkerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float hitMarkerLength = 1f;
    float hitMarkerLeft;
    
    void Start()
    {
        hitMarkerLeft = hitMarkerLength;
    }

    // Update is called once per frame
    void Update()
    {
        hitMarkerLeft -= Time.deltaTime;
        if (hitMarkerLeft <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
