using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Scripting.APIUpdating;

public class PlayerCharacter : MonoBehaviour
{
   public InputActionReference moveAction;
   public float rotationSpeed = 10.0f;

 public float  moveSpeed = 10.0f; 

    private void Start()
    {
        moveAction.action.Enable();
    }

    private void Update()
    {
        Vector2 inputValue = moveAction.action.ReadValue<Vector2>();
        Debug.Log(inputValue);

        Vector3 movementValue = new Vector3(inputValue.x,0 ,inputValue.y);

        //transform.Translate(movementValue * Time.deltaTime * 10f);

        Vector3 desiredPosition = transform.position + movementValue * Time.deltaTime * moveSpeed;

        if (NavMesh.SamplePosition(desiredPosition, out NavMeshHit hit, 0.1f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, , Time.deltaTime * rotationSpeed);
        }
    }
}
