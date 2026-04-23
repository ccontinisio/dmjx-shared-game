using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
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
        if (input3D.sqrMagnitude > 0f)
        {
            Vector3 newPosition = transform.position + input3D * Time.deltaTime * speed;
            bool isValid = NavMesh.SamplePosition(newPosition, out NavMeshHit hit, .3f, NavMesh.AllAreas);
            if (isValid)
            {
                transform.position = hit.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input3D, Vector3.up), Time.deltaTime * speed * 10f);
            }
        }
    }
}
