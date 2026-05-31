using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    private Transform tf;
    private SpriteRenderer theRenderer; 


    public float MovementSpeed = 5.0f;
    public float MinXBound = -5.0f;
    public float MaxXBound = 5.0f;
    public float MinYBound = -5.0f;
    public float MaxYBound = 5.0f;
    public float FastSpeed = 2.0f;
    public float SlowSpeed = 0.5f;
    public Color spriteColor;

   
    protected virtual void Start()
    {
        tf = GetComponent<Transform>();
        theRenderer = GetComponent<SpriteRenderer>();

        spriteColor.a = 1.0f;
    }

    public virtual void RandomPosition()
    {
        float randomX = Random.Range(MinXBound, MaxXBound);
        float randomY = Random.Range(MinYBound, MaxYBound);

        tf.position = new Vector3(randomX, randomY, 0.0f);

        spriteColor.r = Random.Range(0.0f, 1.0f);
        spriteColor.g = Random.Range(0.0f, 1.0f);
        spriteColor.b = Random.Range(0.0f, 1.0f);

        if (theRenderer != null)
        {
            theRenderer.color = spriteColor;
        }
    }

    public virtual void MovePawn(int verticalDirection, int horizontalDirection, bool SpeedIncrease, bool SpeedDecrease)
    {
        if (SpeedDecrease)
        {
            tf.position = tf.position + new Vector3(
                horizontalDirection * Time.deltaTime * MovementSpeed * SlowSpeed,
                verticalDirection * Time.deltaTime * MovementSpeed * SlowSpeed,
                0.0f);
        }
        else if (SpeedIncrease)
        {
            tf.position = tf.position + new Vector3(
                horizontalDirection * Time.deltaTime * MovementSpeed * FastSpeed,
                verticalDirection * Time.deltaTime * MovementSpeed * FastSpeed,
                0.0f);
        }
        else 
        {
            tf.position = tf.position + new Vector3(
                horizontalDirection * Time.deltaTime * MovementSpeed,
                verticalDirection * Time.deltaTime * MovementSpeed,
                0.0f);
        }
    }

    public virtual void ShiftPawn(int verticalDirection, int horizontalDirection)
    {
        tf.position = tf.position + new Vector3(
            horizontalDirection,
            verticalDirection,
            0.0f
        );
    }
}
