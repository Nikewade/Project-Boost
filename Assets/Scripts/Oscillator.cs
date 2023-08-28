using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementFactor;
    [SerializeField] float period = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        // This uses sin to make the transition a lot smoother
        if(period <= Mathf.Epsilon) { return; } // Very small number decimals.. sometimes when comparing floats it does not work
        float cycles = Time.time / period; // Continue to grow over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from - 1 to 1

        movementFactor = (rawSinWave + 1f) / 2; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
