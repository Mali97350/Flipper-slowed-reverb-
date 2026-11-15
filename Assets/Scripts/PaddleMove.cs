using UnityEngine;

public class Paddle : MonoBehaviour
{ 
    public float targetPosition = 75;
    public float originPosition;
    public float speed = 400f;     // speed de la rota 
    private float current;  
    public HingeJoint hinge;

    JointSpring jointSpring;
    
    void Start() 
    {
        current = originPosition;
        jointSpring    = hinge.spring;
    }
  
    void Update()
    {
        float goal;// la destination

        if (Input.GetKey(KeyCode.Space))
        {
            goal = targetPosition;
        }
        else
        {
            goal = originPosition;
        }

        current = Mathf.MoveTowards(current, goal, speed * Time.deltaTime);   
        jointSpring.targetPosition = current;
        hinge.spring = jointSpring;
    }
}