using UnityEngine;

public class ParallaxBehaviour: MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f, 1f)] float parallaxStrenght = 0.1f;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (!followingTarget)
            followingTarget = Camera.main.transform;

        targetPreviousPosition = followingTarget.position;
    }

    void Update()
    {
        var delta = followingTarget.position - targetPreviousPosition;

        if (disableVerticalParallax)
            delta.y = 0;

        targetPreviousPosition = followingTarget.position;

        transform.position += delta * parallaxStrenght;
    }
}