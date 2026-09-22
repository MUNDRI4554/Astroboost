using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength;
    [SerializeField] float rotationStrength;
    Rigidbody rb;

    private void OnEnable()
    {
        rotation.Enable();  
        thrust.Enable();
    } 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        thrust_Ispressed();
        rotation_Ispressed();
    }

    //thrust_Ispressed and rotation_Ispressed are called in FixedUpdate 
    private void thrust_Ispressed()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    private void rotation_Ispressed()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
        }
    }
    //thrust_Ispressed and rotation_Ispressed are called in FixedUpdate 

    private void ApplyRotation(float rotatePerFrame)
    {
       transform.Rotate(Vector3.forward*rotatePerFrame*Time.fixedDeltaTime); 
    }
}
