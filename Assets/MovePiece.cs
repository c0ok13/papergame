using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{

    [SerializeField]
    private Transform piecePlace;

    private Vector2 initalPosition;

    private SpriteRenderer rend;

    private float deltaX, deltaY;

    public bool locked;
    
    private bool rotating ;

    float presstime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        locked = false;
        initalPosition = transform.position;
    }

    private IEnumerator Rotate( Vector3 angles, float duration )
    {
         rotating = true ;
        Quaternion startRotation = transform.rotation ;
        Quaternion endRotation = Quaternion.Euler( angles ) * startRotation ;
        for( float t = 0 ; t < duration ; t+= Time.deltaTime )
        {
            transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration ) ;
            yield return null;
        }
        transform.rotation = endRotation  ;
        rotating = false;
    }

    public void StartRotation()
    {
        if( !rotating )
            StartCoroutine( Rotate( new Vector3(0, 0, 90), 1));
            presstime = 0.0f;
    }
    // Update is called once per frame
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            rend = transform.gameObject.GetComponent<SpriteRenderer>();
            if(!rotating && !locked)
            {
                switch(touch.phase){
                    case TouchPhase.Began:
                        if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)){
                            deltaX = touchPos.x - transform.position.x;
                            deltaY = touchPos.y - transform.position.y;
                            rend.sortingOrder = 10;
                        }
                        break;
                    case TouchPhase.Moved:
                        presstime = 0.0f;
                        if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)){
                            transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                        }        
                        break;
                    case TouchPhase.Ended:   
                        if(Mathf.Abs(transform.position.x - piecePlace.position.x) <= 70 &&
                        Mathf.Abs(transform.position.y - piecePlace.position.y) <= 70 && transform.rotation.z == 00) 
                        {
                            transform.position = new Vector3(piecePlace.position.x, piecePlace.position.y, 150);
                            locked = true;
                            rend.sortingOrder = 2;
                        } else {
                            rend.sortingOrder = 5;
                        }
                        break;
                    case TouchPhase.Stationary: 
                        presstime += Time.deltaTime;
                        if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && presstime >= 0.5f){  
                            StartRotation();
                        }
                        break;    
                    
                }
            }
        }
    }
}
