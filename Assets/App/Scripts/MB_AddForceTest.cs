using UnityEngine;
using UnityEngine.AI;

public class MB_AddForceTest : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0).normalized * force, ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

}
