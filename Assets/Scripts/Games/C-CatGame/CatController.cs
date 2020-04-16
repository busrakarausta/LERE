using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatController : MonoBehaviour,IPointerDownHandler
{
    private Animator anim;
    private int count=0;
    public CatEnder catEnder;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        EatMeal();
    }

    public void EatMeal()
    {
        if (gameObject.name== "Cat")
        {
            anim.SetTrigger("Eat_1");
            catEnder.IncreaseClickCount();
        }
        else if (gameObject.name== "Cat_2")
        {
            anim.SetTrigger("Eat_2");
            catEnder.IncreaseClickCount();
        }
    }

   
}
