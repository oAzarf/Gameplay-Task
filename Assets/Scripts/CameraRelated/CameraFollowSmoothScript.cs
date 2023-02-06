using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSmoothScript : MonoBehaviour
{
    [SerializeField]
    Transform targetToFollow;
    [SerializeField]
    float smoothing = 10f;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - targetToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = targetToFollow.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

    }
}
