using UnityEngine;
using UnityEngine.SceneManagement;

public class VitoriaTrigger : MonoBehaviour
{
    public GameObject painelVitoria;
    public GameObject jogador;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogador.SetActive(false);
            painelVitoria.SetActive(true);
            Debug.Log("GANHASTE!");
        }
    }

    public void JogarNovamente()
    {
        RouboTrigger.foiDetectado = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
