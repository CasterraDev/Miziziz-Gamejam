using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float spd = 2f;

    private float moveLimiter = .7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        if (h != 0 && v != 0)
        {
            h *= moveLimiter;
            v *= moveLimiter;
        }

        transform.Translate(new Vector3(h * spd * Time.deltaTime, v * spd * Time.deltaTime));
    }
}
