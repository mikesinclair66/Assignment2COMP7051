using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AILeftGoal : MonoBehaviour
{
    public Score score;

    void OnCollisionEnter(Collision col)
    {
        PongBall ball = col.gameObject.GetComponent<PongBall>();

        if (ball != null)
        {
            ball.transform.position = new Vector3(0f, 1f, 0f);

            ball.initialImpulse.x = Random.Range(-20, -10);
            ball.initialImpulse.z = Random.Range(-20, -10);

            Debug.Log("x = " + ball.initialImpulse.x);
            Debug.Log("z = " + ball.initialImpulse.z);

            ball.rb.velocity = ball.initialImpulse;

            ball.rb.AddForce(ball.initialImpulse, ForceMode.Impulse);

            score.rightScore++;
            if (score.rightScore == 5)
            {
                SceneManager.LoadScene("TestMaze2");
            }
        }
    }
}
