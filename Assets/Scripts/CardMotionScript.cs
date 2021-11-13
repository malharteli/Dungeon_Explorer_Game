using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMotionScript : MonoBehaviour
{
    public Vector3 target = Vector3.zero;
    public GameObject targetObject;
    public Vector3 parentTarget = Vector3.zero;
    public float speed = 1f;
    public bool targetReached = false;
    // Start is called before the first frame update
    void Start()
    {
        if (parentTarget == Vector3.zero)
        {
            parentTarget = GetComponentInParent<Transform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - target).magnitude < 1f)
        {
            targetReached = true;
        }
        if (Input.GetButtonDown("Jump") && targetObject)
        {
            Move(targetObject);
        }
    }

    void Spin()
    {

    }

    void Move(GameObject target)
    {
        if (targetReached)
        {
            AnimateMoveBack();
            targetReached = false;
        }
        else 
        {
            AnimateMoveTo(target);
        }
    }

    void AnimateMoveTo(GameObject targetObject)
    {
        target = targetObject.transform.position;
        StartCoroutine("MoveToTarget");
    }

    void AnimateMoveBack()
    {
        StartCoroutine("MoveToParent");
    }

    IEnumerator MoveToParent()
    {
        if ((transform.position - parentTarget).magnitude> 1f)
        {
            Debug.Log("Moving Back");
            while ((transform.position - parentTarget).magnitude > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, parentTarget, speed*Time.deltaTime * (transform.position - parentTarget).magnitude);
                yield return null;
            }
        }
    }
    IEnumerator MoveToTarget()
    {
        if ((transform.position - target).magnitude > 1f)
        {
            Debug.Log("Moving to Target");
            while ((transform.position - target).magnitude > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime*(transform.position - target).magnitude);
                yield return null;
            }
        }
    }
}
