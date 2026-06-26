using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private Sprite unLitSprite;
    [SerializeField] private Sprite litSprite;
    private SpriteRenderer spriteRenderer;
    private bool isLit = false;

    [Header("To Handle Interactions")]
    private GameObject player;
    public float interactRng;
    public InputActionAsset inputActions;

    private InputAction interactAction;

    
    private Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.GetComponent<Transform>();

    }

    void Awake()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
          player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasInteracted() && isLit)
        {
                GameManager.instance.roomsCleared ++;
                GameManager.instance.phase = 0;
                SceneManager.LoadScene("Main");
        }
    }



    public void lightDoor()
    {
        isLit = true;
        spriteRenderer.sprite = litSprite;
    }
    public void unLightDoor()
    {
        isLit = false;
        spriteRenderer.sprite = unLitSprite;
    }

    private bool HasInteracted()
    {


        Vector2 playerPosition = playerTransform.position;
        Vector2 objectPosition = transform.position;

       
        
        float distance = Vector2.Distance(playerPosition, objectPosition);

        if (distance < interactRng && interactAction.WasPressedThisFrame())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
