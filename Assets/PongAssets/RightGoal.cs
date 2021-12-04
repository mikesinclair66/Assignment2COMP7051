using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightGoal : MonoBehaviour
{
    public Score score;

    void OnCollisionEnter(Collision col)
    {
        PongBall ball = col.gameObject.GetComponent<PongBall>();

        if (ball != null)
        {
            ball.transform.position = new Vector3(0f, 1f, 0f);

            ball.initialImpulse.x = Random.Range(10, 20);
            ball.initialImpulse.z = Random.Range(10, 20);

            Debug.Log("x = " + ball.initialImpulse.x);
            Debug.Log("z = " + ball.initialImpulse.z);

            ball.rb.velocity = ball.initialImpulse;

            ball.rb.AddForce(ball.initialImpulse, ForceMode.Impulse);

            score.leftScore++;
            if (score.leftScore == 5)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
