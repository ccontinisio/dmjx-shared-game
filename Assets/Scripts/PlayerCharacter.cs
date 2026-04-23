using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    public Transform desiredPositionDebug;
    public Transform sampledPositionDebug;
    
    public InputActionReference moveAction;
    public float speed = 5f;

    private void Start()
    {
        moveAction.action.Enable();
    }

    private void Update()
    {
        Vector2 inputValue = moveAction.action.ReadValue<Vector2>();
        Vector3 input3D = new Vector3(inputValue.x, 0f, inputValue.y);
        
        // Only move if there is any input, i.e. the length of the movement vector is above 0
        if (input3D.sqrMagnitude > 0f)
        {
            Vector3 desiredPosition = transform.position + input3D * Time.deltaTime * speed;
            desiredPositionDebug.position = desiredPosition;
            
            bool isValid = NavMesh.SamplePosition(desiredPosition, out NavMeshHit hit, .3f, NavMesh.AllAreas);
            if (isValid)
            {
                transform.position = hit.position;
                sampledPositionDebug.position = hit.position;
                
                // Rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input3D, Vector3.up), Time.deltaTime * speed * 10f);
            }
        }
    }
}
