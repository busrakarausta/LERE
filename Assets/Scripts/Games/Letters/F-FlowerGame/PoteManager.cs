using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoteManager : MonoBehaviour,IPointerDownHandler{
    
    private Rigidbody2D petal;
    public FlowerEnder flowerEnder;

    void Awake()
    {
        petal = gameObject.GetComponent<Rigidbody2D>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(MovePetal());
        flowerEnder.IncreaseClickCount();
    }

    public IEnumerator MovePetal()
    {
        if (gameObject.name == "Petal1" || gameObject.name == "Petal3" || gameObject.name == "Petal5")
        {
            petal.velocity = new Vector2(-120f, -200f);
            yield return new WaitForSeconds(5);
            gameObject.SetActive(false);
        }
        else
        {
            petal.velocity = new Vector2(120f, -200f);
            yield return new WaitForSeconds(5);
            gameObject.SetActive(false);
        }
    }
}
