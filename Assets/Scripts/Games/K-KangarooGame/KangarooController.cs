using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KangarooController : MonoBehaviour,IPointerDownHandler
{
    private Animator anim;
    private Animator anim_momChild;
    public GameObject Mom_cangaroo;
    public GameObject MomWithChild;
    private AudioSource source;
    public event Action OnLevelEnd;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        anim_momChild = MomWithChild.GetComponent<Animator>();
        source = MomWithChild.GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        anim.SetTrigger("KangarooJump");
        StartCoroutine(GetChild());
        OnLevelEnd?.Invoke();
    }

    public IEnumerator GetChild()
    {
        yield return new WaitForSeconds(0.5f);
        Mom_cangaroo.SetActive(false);
        gameObject.SetActive(false);
        MomWithChild.SetActive(true);
        source.Play();
        yield return new WaitForSeconds(0.5f);
        anim_momChild.SetTrigger("MomKangaroo");
    }
}
