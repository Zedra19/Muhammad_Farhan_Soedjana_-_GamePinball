using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] bool kanan, kiri;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxRotationAngle;
    [SerializeField] float force;
    public GameObject paddleSFX;
    AudioSource SFX;
    bool isSFXPlayed = false;
    Vector3 startRotation;
    bool touched = false;

    private void Awake()
    {
        startRotation = transform.rotation.eulerAngles;
        paddleSFX = GameObject.Find("PaddleSFX");
        SFX = paddleSFX.GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        controller();
    }

    private void controller()
    {
        if (kanan)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                var targetRotation = Quaternion.Euler(startRotation + new Vector3(0, 0, -maxRotationAngle));
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                if (!isSFXPlayed)
                {
                    SFX.Play();
                    isSFXPlayed = true;
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(startRotation);
                isSFXPlayed = false;
            }
        }
        else if (kiri)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                var targetRotation = Quaternion.Euler(startRotation + new Vector3(0, 0, maxRotationAngle));
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                if (!isSFXPlayed)
                {
                    SFX.Play();
                    isSFXPlayed = true;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(startRotation);
                isSFXPlayed = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touched = true;
            if (touched && (Input.GetKey(KeyCode.LeftArrow)) && kiri)
            {
                Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                ballRigidbody.velocity = new Vector3(ballRigidbody.velocity.x, force, ballRigidbody.velocity.z);
            }else if (touched && (Input.GetKey(KeyCode.RightArrow)) && kanan)
            {
                Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                ballRigidbody.velocity = new Vector3(ballRigidbody.velocity.x, force, ballRigidbody.velocity.z);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touched = false;
        }
    }
}
