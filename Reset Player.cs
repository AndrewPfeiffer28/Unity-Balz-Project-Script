using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ResetPlayer : MonoBehaviour
{
    public float restYThreahold = -20f;
    public Vector3 startingPosition = new Vector3(0f, 0.5f, 0f);
    public float defaultDrag = 1f;
    public Transform parentObject;
    public PlayerController playerController;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            defaultDrag = rb.drag;
        }
    }

    void ActivateChildrenOfParent(Transform parent)
    {
        if (parent != null)
        {
            // Iterate through the children
            foreach (Transform child in parent)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Parent object did not work");
        }
        
    }

    void Update()
    {
        if (transform.position.y < restYThreahold)
        {
            transform.position = startingPosition;

            ResetPhysics();
            ActivateChildrenOfParent(parentObject);
            playerController.ResetCount();
            
            


        }
    }
  

    void ResetPhysics()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularDrag = 0f;
            rb.angularVelocity = Vector3.zero;
            rb.drag = defaultDrag;
        }
    }
}

