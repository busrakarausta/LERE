using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GuitarManager : MonoBehaviour, IPointerDownHandler
{
    public GameObject canvas;
    public Transform nota;

    public GameObject notaObject;
    private GameObject insObj;
    private AudioSource source;
    private Animator anim;
    private int clickCount = 0;

    
    void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        clickCount++;
        if (clickCount <= 4)
        {
            createSoundAndAnim(gameObject);
        }
        else
        {
            Debug.Log("PASS GAME");
        }
    }
    
    public IEnumerator CreateNota()
    {
        insObj=Instantiate(notaObject, nota.position, Quaternion.identity);
        insObj.SetActive(true);
        insObj.transform.SetParent(nota,true);
        insObj.transform.parent = canvas.transform;
        insObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 50f);
        
        yield return new WaitForSeconds(1f);
        Destroy(insObj);
    }

    public void createSoundAndAnim(GameObject gObject)
    {     
        anim.SetTrigger("Play");
        source.Play();
        StartCoroutine(CreateNota());
    }
}
