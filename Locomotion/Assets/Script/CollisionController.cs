using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameObject personal;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.CompareTag("Dead")) {
            personal.GetComponent<Personal>().Dead();
            GameObject.FindGameObjectWithTag("GUI").GetComponent<GUIController>().UpdateCountPersonal();
        }
    }
}
