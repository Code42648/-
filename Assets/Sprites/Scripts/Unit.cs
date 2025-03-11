using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public virtual void ReceiveDamage()  // функция получения урона
    {
        Die();  //  функция смерти
    }

    protected virtual void Die()
    {
        Destroy(gameObject);  //  уничтожить объект
    }
}
