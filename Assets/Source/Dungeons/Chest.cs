using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Chest : MonoBehaviour
{
    public Sprite OpenChestSprite;
    public Sprite ClosedChestSprite;

    private Collider2D trigger;
    private SpriteRenderer sr;
    private LootType lootType;
    private bool opened;

    public void SetLoot(LootType type)
    {
        lootType = type;
    }

    private void Awake()
    {
        trigger = GetComponent<Collider2D>();
        trigger.isTrigger = true;

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = ClosedChestSprite;

        lootType = Loot.RandomEnum<LootType>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger hit by: {other.gameObject.name} tag: {other.tag}");
        if (opened) return;
        if (other.CompareTag("Player"))
            OpenChest();
    }

    private void Update()
    {
        sr.sprite = opened ? OpenChestSprite : ClosedChestSprite;
    }

    private void OpenChest()
    {
        opened = true;
        Debug.Log($"Chest opened! Loot: {lootType}");
        // BuffManager.Apply(...) etc.
    }
}