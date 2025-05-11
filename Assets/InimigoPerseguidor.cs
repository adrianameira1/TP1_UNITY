using UnityEngine;

public class InimigoPerseguidor : MonoBehaviour
{
    public Transform alvo; // Jogador
    public float velocidade = 2f;

    void Update()
    {
        if (RouboTrigger.foiDetectado && alvo != null)
        {
            // Move até ao jogador
            transform.position = Vector2.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);

            // Vira o inimigo visualmente para o jogador
            if (transform.position.x > alvo.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameOverManager go = FindObjectOfType<GameOverManager>();
            if (go != null)
            {
                go.GameOver();
            }
        }
    }
}
