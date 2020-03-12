using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XylophoneManager : MonoBehaviour,IPointerDownHandler
{
    private AudioSource source;
    public GameObject notaObject;
    public Transform nota;
    public GameObject canvas;
    private GameObject insObj;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        source.Play();
        StartCoroutine(CreateNota());

    }
    public IEnumerator CreateNota()
    {
        insObj=Instantiate(notaObject, gameObject.transform.position, Quaternion.identity);
        insObj.SetActive(true);
        insObj.transform.SetParent(nota,true);
        insObj.transform.parent = canvas.transform;
        insObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 50f);
        yield return new WaitForSeconds(1f);
        Destroy(insObj);
    }
    
}
