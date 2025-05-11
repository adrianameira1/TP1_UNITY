using UnityEngine;

public class RouboTrigger : MonoBehaviour
{
    public static bool foiDetectado = false;
    public GameObject inimigoParaAtivar; // arrastar o inimigo aqui

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !foiDetectado)
        {
            foiDetectado = true;

            if (inimigoParaAtivar != null)
                inimigoParaAtivar.SetActive(true); // ativa o inimigo escondido

            Debug.Log("ROUBO ATIVADO!");
        }
    }
}
