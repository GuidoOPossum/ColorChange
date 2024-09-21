using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
public class SceneChangerButton : MonoBehaviour , IPointerUpHandler
{
    [SerializeField] private string sceneName = "GameplayScene";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeScene()
    {
        PauseManager.instanse.ResumeGame();
        SceneManager.LoadScene(sceneName);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ChangeScene();
        
    }
}
