using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform car;
    public float forwardLook = 2;
    public float distance = 4; 
    public float height = 5;
    public float smoothTime = 0.3f;
    private Vector3 vel = Vector3.zero; 
    
   
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if(car == null)
        {
            Debug.Log("No car dude.");
            return;
        }

        transform.LookAt(car.position + car.forward * forwardLook);
        Vector3 desiredPosn = car.position - distance*car.forward + height*Vector3.up;
        

        
        
        transform.position = Vector3.Lerp(transform.position, desiredPosn, smoothTime* Time.deltaTime);

    }
}
