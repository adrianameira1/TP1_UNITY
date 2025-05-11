using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject painelGameOver; // Painel da UI
    public GameObject jogador;        // Referência ao jogador

    private bool gameOverAtivo = false;

    void Update()
    {
        if (!gameOverAtivo && jogador != null)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(jogador.transform.position);
            if (pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        if (gameOverAtivo) return;

        gameOverAtivo = true;
        if (painelGameOver != null)
            painelGameOver.SetActive(true);

        if (jogador != null)
            jogador.SetActive(false);
    }

    public void RecomecarJogo()
    {
        RouboTrigger.foiDetectado = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
