using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GuitarManager : MonoBehaviour, IPointerDownHandler
{
    //public GameObject canvas;
    public Transform nota;
    public GameObject guitar;
    public GuitarEnder guitarEnder;
    public GameObject notaObject;
    private GameObject insObj;
    private AudioSource source;
    private int clickCount = 0;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        guitarEnder.IncreaseNoteCount();
        createSound(gameObject);
    }
    
    public IEnumerator CreateNota()
    {
        insObj=Instantiate(notaObject, nota.position, Quaternion.identity);
        insObj.SetActive(true);
        insObj.transform.SetParent(nota,true);
        insObj.transform.parent = guitar.transform;
        insObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 200f); 
        yield return new WaitForSeconds(1f);
        Destroy(insObj);
    }

    public void createSound(GameObject gObject)
    {     
        source.Play();
        StartCoroutine(CreateNota());
    }
}
