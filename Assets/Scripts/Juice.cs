using UnityEditor.Callbacks;
using UnityEngine;

public class Juice : MonoBehaviour
{
    private Camera cam; 
    [SerializeField]private CarController car;
    public float defaultFOV = 60;
    public float MaxFOV = 85;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Vector3.Magnitude(car.rb.linearVelocity);
        Mathf.Clamp(speed, 0, car.TopSpeed);

        cam.fieldOfView = Mathf.Lerp(defaultFOV, MaxFOV, speed/car.TopSpeed);


    }
}
