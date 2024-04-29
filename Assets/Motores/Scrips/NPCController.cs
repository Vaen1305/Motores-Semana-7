using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class NPCController : MonoBehaviour
{
    public Transform[] movementPoints; 
    public float moveSpeed = 2f; 
    public float waitTime = 2f;
    public bool isMoving = true;
    private int currentPointIndex = 0;

    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private GameObject interactionMessage;

    void Start()
    {
        StartCoroutine(MoveNPC());
    }

    IEnumerator MoveNPC()
    {
        while (true) 
        {
            if (isMoving)
            {
                Vector3 targetPosition = movementPoints[currentPointIndex].position;

                while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                    yield return null;
                }

                yield return new WaitForSeconds(waitTime);

                currentPointIndex = (currentPointIndex + 1) % movementPoints.Length;
            }
            else
            {
                yield return null; 
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = false;
            interactionMessage.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true;
            interactionMessage.SetActive(false);
        }
    }
    
}
