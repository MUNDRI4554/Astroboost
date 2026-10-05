using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength;
    [SerializeField] float rotationStrength;
    [SerializeField] AudioClip engineThrust;
    [SerializeField] ParticleSystem mainThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    Rigidbody rb;
    AudioSource audiosource;

    private void OnEnable()
    {
        rotation.Enable();  
        thrust.Enable();
    } 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void rotation_Ispressed()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput < 0)
        {
            LeftRotation();
        }
        else if (rotationInput > 0)
        {
            RightRotation();
        }
        else
        {
            StopRotation();
        }
    }

    //StopRotation, RightRotation, LeftRotation, ApplyRotation is called in rotation_isPressed

    private void StopRotation()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

    private void RightRotation()
    {
        ApplyRotation(-rotationStrength);
        if (!rightThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Stop();
            rightThrusterParticles.Play();
        }
    }

    private void LeftRotation()
    {
        ApplyRotation(rotationStrength);
        if (!leftThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Stop();
            leftThrusterParticles.Play();
        }
    }

    private void ApplyRotation(float rotatePerFrame)
    {
       rb.freezeRotation = true;
       transform.Rotate(Vector3.forward* rotatePerFrame *Time.fixedDeltaTime); 
       rb.freezeRotation = false;
    }

    //StopThrusting and StartThrusting is called in thrust_Ispressed

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);

        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(engineThrust);
        }
        if (!mainThrusterParticles.isPlaying)
        {
            mainThrusterParticles.Play();
        }
    }

    private void StopThrusting()
    {
        audiosource.Stop();
        mainThrusterParticles.Stop();
    }
}


