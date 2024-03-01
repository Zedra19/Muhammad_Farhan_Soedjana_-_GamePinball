using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToBall : MonoBehaviour
{
    public Rigidbody ball;
    private float hasilForce = 0;
    [SerializeField] private float force;
    [SerializeField] private float maxForce;
    bool playing = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                hasilForce += force * Time.deltaTime;
                hasilForce = Mathf.Clamp(hasilForce, 0, maxForce);
                var warna = Color.Lerp(Color.white, Color.red, hasilForce / 10f);
                GetComponent<Renderer>().material.color = warna;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ball.AddForce(hasilForce * Vector3.up, ForceMode.Impulse);
                playing = true;
                hasilForce = 0;
                GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playing = false;
        }
    }
}
