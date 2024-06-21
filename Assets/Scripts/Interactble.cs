using UnityEngine;

public abstract class Interactble : MonoBehaviour
{

    public string promtMessage;

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //Пустая функция чтобы перезаписывать
    }
}
