using UnityEngine;
using System.Collections;

public class SlideObject : MonoBehaviour
{
    // default speed = (slow is 3)
    public float speed;
    public Vector3 startpoint;
    public Vector3 endpoint;

    private void Start()
    {
        // Start the movement coroutine when the script is initialized
        StartCoroutine(MoveSequence());
    }

    private IEnumerator MoveSequence()
    {
        while (true) // Infinite loop for continuous looping
        {
            // Move to the endpoint
            yield return MoveObjectCoroutine(endpoint);

            // Move back to the startpoint
            yield return MoveObjectCoroutine(startpoint);
        }
    }

    private IEnumerator MoveObjectCoroutine(Vector3 target)
    {
        while (transform.position != target)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Wait for the next frame
            yield return null;
        }
    }
}
