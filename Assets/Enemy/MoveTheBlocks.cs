using UnityEngine;

public class MoveTheBlocks : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float increasedSpeed = 5;
    private float originalSpeed;
    private Player _player;
    private void Awake()
    {
       
        originalSpeed = speed;
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.onTopExit += SetDecreaseSpeed;
        _player.onTopStay += SetIncreaseSpeed;
    } 
    
    private void OnDisable()
    {
        _player.onTopExit -= SetDecreaseSpeed;
        _player.onTopStay -= SetIncreaseSpeed;
    }

    void Update()
    {
        float currentSpeed = speed * Time.deltaTime * Timer.time/30;
        transform.position -= new Vector3(0, currentSpeed, 0);
        //print("Speed:" + currentSpeed);
    }

    private void SetIncreaseSpeed() => speed = increasedSpeed;
    private void SetDecreaseSpeed() => speed = originalSpeed;
    
}
