using UnityEngine;

public class Patrolenemy : MonoBehaviour
{
    private Vector3 LocationA;
    private Vector3 LocationB;
    private Vector3 nextLocation;

    [SerializeField] private Transform Enemy;
    [SerializeField] private Transform onThemove;

    public float speed;
    private bool facingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LocationA = Enemy.localPosition;
        LocationB = onThemove.localPosition;
        nextLocation = LocationB;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Enemy.localPosition = Vector3.MoveTowards(Enemy.localPosition, nextLocation, speed * Time.deltaTime);

        if(Vector3.Distance(Enemy.localPosition,nextLocation) <= 0.1)
        {
            ChangePosition();
            flipEnemy();
        }


    }

    private void ChangePosition()
    {
        nextLocation = nextLocation != LocationA ? LocationA : LocationB;
    }

    public void flipEnemy()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    
        
    

}