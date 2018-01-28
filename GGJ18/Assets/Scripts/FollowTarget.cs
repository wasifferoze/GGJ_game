using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] public GameObject Target;

    private Vector3 TargetOffset;

    private void Start()
    {
        TargetOffset = Target.transform.position - transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            Target.transform.position - TargetOffset,
            0.1f * Time.time
        );
    }
}
