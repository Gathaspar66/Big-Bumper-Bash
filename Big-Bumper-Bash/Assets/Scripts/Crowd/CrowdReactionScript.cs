using UnityEngine;

public class CrowdReactionScript : MonoBehaviour
{
    public float jumpHeight = 2.0f;
    public float jumpDuration = 1.0f;
    public float delayBetweenJumps = 1.0f;

    private float startY;
    private bool isJumping = false;
    private float jumpTimer = 0.0f;
    private float jumpDelayTimer = 0.0f;


    void Start()
    {
        startY = transform.position.y;
        jumpDelayTimer = Random.Range(0.0f, delayBetweenJumps);
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        jumpDelayTimer -= Time.deltaTime;

        if (jumpDelayTimer <= 0)
        {
            if (!isJumping)
            {
                isJumping = true;
                jumpTimer = 0.0f;
            }

            if (isJumping)
            {
                if (jumpTimer < jumpDuration)
                {
                    float newY = startY + Mathf.Sin(jumpTimer / jumpDuration * Mathf.PI) * jumpHeight;
                    transform.position = new Vector3(transform.position.x, newY, transform.position.z);

                    jumpTimer += Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                    jumpDelayTimer = delayBetweenJumps + Random.Range(0.0f, 1.0f);
                }
            }
        }
    }
}

