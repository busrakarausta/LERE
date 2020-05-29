using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoalBallController : MonoBehaviour, IDragHandler
{
    public Transform castle;
    private bool flag = false;
    public CastleController castleController;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        gameObject.transform.position = pos;
        if (flag)
        {
            transform.position = castle.transform.position;
        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Castle")
        {
            Vector3 lastScale = transform.localScale;
            Vector3 finalScale = lastScale * 0.7f;

            while (transform.localScale.magnitude >= finalScale.magnitude)
            {
                transform.localScale = transform.localScale * 0.9f;
                yield return new WaitForSeconds(0.1f);
            }
            flag = true;
            castleController.IncreaseGoalCount();

        }
    }
}
