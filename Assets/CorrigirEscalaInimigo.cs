using UnityEngine;

public class CorrigirEscalaInimigo : MonoBehaviour
{
    private Vector3 escalaOriginal;

    void Awake()
    {
        escalaOriginal = transform.localScale;
    }

    void OnEnable()
    {
        transform.localScale = escalaOriginal;
    }
}
