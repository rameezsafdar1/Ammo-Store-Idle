using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFly : MonoBehaviour
{
    public Transform targetPosition;
    private float speed, timer;
    public float timeToReach;
    private Vector3 startPos;

    private void Start()
    {
        startPos = GetComponent<RectTransform>().position;
    }

    private void Update()
    {

        timer += Time.deltaTime;
        speed += Time.deltaTime / timeToReach;

        transform.position = Vector3.Lerp(startPos, targetPosition.position, speed);

        if (Vector3.Distance(transform.position, targetPosition.position) <= 0.5f)
        {
            timer = 0;
            speed = 0;
            enabled = false;
            transform.position = startPos;
            gameObject.SetActive(false);
        }

    }
}
