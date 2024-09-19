using UnityEngine;

public class PeackablItem : Item, IPeackablItem
{
    public void OnPeacked()
    {
        gameObject.SetActive(false);
    }

    public void OnDropped()
    {

    }
}