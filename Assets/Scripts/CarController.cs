

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class CarController : MonoBehaviour
{
    private Rigidbody rb;

    public Transform[] thrusters;

    [Header("Suspensions")]
    public float restingHeight = 4f;
    public float springForce = 4f;
    public float dampingCoeffecient = 4f;
    
    [Header("Grip")]
    [Range(0f, 1f)] public float frontFrictionCoeff = 0.6f;
    [Range(0f, 1f)] public float rearFrictionCoeff = 0.6f;
    
    [Header("Engine")]
    public float acceleration = 3f;
    
    [Header("Steering")]
    public float turnAngle = 20;


    //-------Input--------//

    Vector2 movement;
    bool brakes;

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
            brakes = true;
    }

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

   
    void FixedUpdate()
    {
        if(thrusters.Length == 4)
        {
            Suspensions();
            Engines();
            Grip();
            Steer();
        }
    }

    void Suspensions()
    {
        foreach(Transform t in thrusters)
        {
            RaycastHit hit;
            if(Physics.Raycast(t.position, -t.up, out hit, restingHeight))
            {
                //General Variables 
                Vector3 velocity = rb.GetPointVelocity(t.position);
                float d = hit.distance;
                
                //Suspension
                Vector3 x = (1 - (d/restingHeight)) *t.up ;
                float k =  rb.mass/4 *springForce*  Vector3.Magnitude(Physics.gravity);
                Debug.DrawRay(t.position, k*x, Color.beige);
                Vector3 suspensionForce = k*x;

                //Damping
                float v = Vector3.Dot(velocity, t.up);
                float dampMagnitude = -dampingCoeffecient*rb.mass/4 * v;
                Vector3 dampForce = dampMagnitude * t.up;
                
                //Total Forces
                Vector3 TotalForce = suspensionForce + dampForce;
                rb.AddForceAtPosition(TotalForce, t.position);



            }

        }
    }
    void Grip()
    {
        //Front
        for(int i = 0; i < 2; i++ )
        {
            Transform t = thrusters[i];
            if(Physics.Raycast(t.position, -t.up,  restingHeight))
            {
                
                
                Vector3 velocity = rb.GetPointVelocity(t.position);
                float sideVelocity = Vector3.Dot(velocity, t.right);
                float gripForce = rb.mass/4 * Vector3.Magnitude(Physics.gravity)*sideVelocity;

                Vector3 totalForce = -frontFrictionCoeff * gripForce * t.right;
                Debug.DrawRay(t.position, totalForce, Color.red);
                rb.AddForceAtPosition(totalForce, t.position);
            }   
        }
        
        //Rear
        for(int i = 2; i < 4; i++ )
        {
            Transform t = thrusters[i];
            if(Physics.Raycast(t.position, -t.up, restingHeight))
            {
                
                Vector3 velocity = rb.GetPointVelocity(t.position);
                float sideVelocity = Vector3.Dot(velocity, t.right);
                float gripForce = rb.mass/4 * Vector3.Magnitude(Physics.gravity)*sideVelocity;

                Vector3 totalForce = -rearFrictionCoeff * gripForce * t.right;
                Debug.DrawRay(t.position, totalForce, Color.red);
                rb.AddForceAtPosition(totalForce, t.position);
            }
            
        }
    }

    void Engines()
    {
        float power = movement.y;

        for(int i = 2; i < 4; i++)
        {
            float force = rb.mass/2 * acceleration* power;
            Debug.DrawRay(thrusters[i].position, force * thrusters[i].forward);
            rb.AddForceAtPosition(force*thrusters[i].forward, thrusters[i].position);
        }
    }

    void Steer()
    {
        float turnInput = movement.x;

        for(int i = 0; i < 2; i++)
        {
            thrusters[i].localRotation = Quaternion.Euler(0f, turnAngle*turnInput, 0f);
            Debug.DrawRay(thrusters[i].position, thrusters[i].forward*2);
        }
    }
   

}
