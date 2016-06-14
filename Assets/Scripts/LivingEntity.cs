using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivingEntity : MonoBehaviour {


    public float life;
    public bool comImagem;
    public Image imagemHP;

    public void Hit(float damange)
    {
        life -= damange;
    }
    void Update()
    {
        if (comImagem)
        {
            imagemHP.fillAmount = (life / 100f);
        }
        if (life <= 0)
        {
            Destroy(gameObject,1f);
        }
    }
}
