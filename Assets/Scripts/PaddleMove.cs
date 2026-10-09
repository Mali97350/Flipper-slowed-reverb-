using UnityEngine;

public class Paddle : MonoBehaviour
{ 
    public float targetPosition = 75;
    public float originPosition;
    
    public HingeJoint hinge;

    JointSpring jointSpring;
    
    void Start() 
    {
        jointSpring    = hinge.spring;
    }
  
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jointSpring.targetPosition = targetPosition;
        }
        else
        {
            jointSpring.targetPosition = originPosition;
        }

        hinge.spring = jointSpring;
    }
}