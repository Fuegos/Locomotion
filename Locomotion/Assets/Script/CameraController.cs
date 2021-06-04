using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed = 1;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition +=
                new Vector3(0, 0, speed * Time.deltaTime);
    }
}
