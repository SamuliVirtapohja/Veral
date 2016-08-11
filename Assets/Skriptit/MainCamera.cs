using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public GameObject target;

    public Vector3 offset;


    // Use this for initialization
    void Start()
    {

        // määrittää
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 desiredPosition = target.transform.position + offset;
        transform.position = desiredPosition;

        // Komentaa kameraa katsomaan targetia (pelaajaa)
        transform.LookAt(target.transform);


    }
}
