using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{

    [SerializeField] Transform targetToFollow;
    [SerializeField, Range(0f, 1f)] float parallaxStrength;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPosition;


    
    void Start()
    {
        if (!targetToFollow)
            targetToFollow = Camera.main.transform;

        targetPreviousPosition = targetToFollow.position;
    }

    void Update()
    {
        Vector3 delta = targetToFollow.position - targetPreviousPosition;

        if (disableVerticalParallax)
            delta.y = 0;

        targetPreviousPosition = targetToFollow.position;

        transform.position += delta * parallaxStrength;
    }
}
