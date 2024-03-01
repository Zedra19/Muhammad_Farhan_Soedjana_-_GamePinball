using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Camera cam;
    public Transform ballPos;
    public GameObject playBorder;
    [SerializeField] float xDariBola,yDariBola,zDariBola, yChangePosition, xPlayPosition, yPlayPosition, zPlayPosition;
    Vector3 playPos;
    bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        playPos = new Vector3(xPlayPosition, yPlayPosition, zPlayPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            cam.transform.position = playPos;
        }else if (!playing)
        {
            cam.transform.position = ballPos.position + new Vector3(xDariBola, yDariBola, zDariBola);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.transform.position.y > transform.position.y)
        {
            playing = true;
            GetComponent<Collider>().isTrigger = false;
            playBorder.SetActive(true);
        }
    }
}
