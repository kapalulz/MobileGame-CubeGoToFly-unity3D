using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private float speed;
    [SerializeField] private float height;
    [SerializeField] private Sprite[] spritesDamage;
    [SerializeField] private GameObject NonActiveBoard;
    [SerializeField] private GameObject deathMenuUI;
   // [SerializeField] private GameObject ButtonContinue;
   // [SerializeField] private GameObject ButtonContinueD;
    [SerializeField] private GameObject Ball;
    [SerializeField] private Score _score;
    public Animator anim;
    public static int health = 3;
    public bool _topEnter = true;
    public event Action onTopExit, onTopStay, onTopEnter;
    public static bool inAir;
    private SpriteRenderer spriteRenderer;
    public InterstitialReclam InterstitialReclam;
    private float x, y, dx, dy;
    private Camera _camera;


    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        x = NonActiveBoard.GetComponent<RectTransform>().position.x;
        y = NonActiveBoard.GetComponent<RectTransform>().position.y;
        dx = NonActiveBoard.GetComponent<RectTransform>().rect.width;
        dy = NonActiveBoard.GetComponent<RectTransform>().rect.height;

        Vector3 thePosition = transform.TransformPoint(2, 0, 0);

        int a = 5;
        int b = a;
        b++;
        inAir = false; // bug1
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
      
    }
    

    void Update()
    {
        if (transform.position.y > height && _topEnter == true)
        {
            onTopEnter?.Invoke();
            _topEnter = false;
        }
        else if (transform.position.y < height && _topEnter == false)
        {
            onTopExit?.Invoke();
            _topEnter = true;
        }

        if (transform.position.y > height)
            onTopStay?.Invoke();


        if (inAir == false)
        {
            if (PressListener.IsPressDown() && !PressListener.IsPointerOverInteractableUI())
            {
                gameObject.GetComponent<Rigidbody2D>().mass = 0.5f;
                Vector2 mouseCord = _camera.ScreenToWorldPoint(PressListener.GetPressScreenPosition()) - transform.position;
                
                GetComponent<Rigidbody2D>().AddForce(mouseCord.normalized * speed);
                inAir = true;
            }
        }


        print("HEALTHS:" + health);
    }
    
    
    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy restart))
        {
            health -= 1;
            //Минус жиза
            if (health == 2)
            {
                Destroy(hearts[2]);
                spriteRenderer.sprite = spritesDamage[0];
            }

            if (health == 1)
            {
                Destroy(hearts[1]);
                spriteRenderer.sprite = spritesDamage[1];
            }

            //Смерть
            if (health == 0)
            {

                //transform.position = transform.position + new Vector3(99, 99, 0);
                _score.ScorePause();
                deathMenuUI.SetActive(true);
                InterstitialReclam.Show();
                // Destroy(GameObject.FindWithTag("Clear"));
              

            }
        }

        if (other.gameObject.TryGetComponent(out Wall checkAir))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            inAir = false;
        }

        if (other.gameObject.TryGetComponent(out Friendly timeWatch))
        {
            Time.timeScale = 0.5f;
            StartCoroutine(TwoSec());
            inAir = false;
        }
    }

    public IEnumerator Death()
    {
        //anim.SetTrigger("death");
      
        yield return new WaitForSeconds(1.0f);
        inAir = false;
        transform.position = new Vector3(0.2f, -5f, 0);
        deathMenuUI.gameObject.SetActive(true);
        _score.ScorePause();
        health = 3;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public IEnumerator TwoSec()
    {
        yield return new WaitForSeconds(2.0f);
        Time.timeScale = 1f;
    }
}