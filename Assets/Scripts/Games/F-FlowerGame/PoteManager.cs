using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoteManager : MonoBehaviour,IPointerDownHandler{

    private Vector3 targetPosition;
    private Vector3 currentPosition;
    public Transform petal;

    public void OnPointerDown(PointerEventData eventData)
    {
       //StartCoroutine(MovePetal());
    }
    
    /*
    public IEnumerator MovePetal()
    {
       
        currentPosition= gameObject.transform.position;
        if(gameObject.name== "Petal1" || gameObject.name== "Petal2" || gameObject.name== "Petal4")
        {
        targetPosition= new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-10f, gameObject.transform.position.z);
        gameObject.transform.position= Vector3.Lerp(transform.position, transform.position+targetPosition , 50f / 10f * Time.deltaTime);
        }
        else
        {
            targetPosition= new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+10f, gameObject.transform.position.z);
            gameObject.transform.position= Vector3.Lerp(transform.position, transform.position+targetPosition , 50f / 10f * Time.deltaTime);
        }
        yield return new WaitForSeconds (1);
        
    }
    */
}
