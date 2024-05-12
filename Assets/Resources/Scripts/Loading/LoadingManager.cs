using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [Header("Current")]
    public GameObject modelPos;
    public MeshFilter modelFilter;
    public MeshRenderer modelRenderer;

    [Header("Information")]
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    [Header("ProgressBar")]
    public TextMeshProUGUI loadingProgress;
    public Image loadingImage;

    [Header("Config")]
    public LoadingModel[] modelList;

    [Header("Model Incremental Rotation")]
    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;

    private LoadingModel currentLoadingModel;
    private bool disableCoroutine = false;

    private const float rotationSpeed = 0.125f;
    private const int timer = 5;
    private const string loadingDoneText = "Pressione [ESPAÇO] para continuar";

    void Start()
    {
        StartCoroutine(ChangeCurrentModel());

        if(LoadingPersistence.nextScene != null)
            StartCoroutine(LoadSceneAsync(LoadingPersistence.nextScene));
        else
            StartCoroutine(LoadSceneAsync("Mall"));
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            disableCoroutine = true;
            NextModel();
        }
    }

    void LateUpdate()
    {
        RotationUtil.IncrementalRotate(modelPos, Space.World, rotationSpeed, rotateX, rotateY, rotateZ);
    }

    private IEnumerator ChangeCurrentModel()
    {
        if(disableCoroutine)
            yield break;

        NextModel();

        yield return new WaitForSeconds(timer);

        StartCoroutine(ChangeCurrentModel());
    }

    private void NextModel()
    {
        SetRandomModel();

        modelPos.transform.localScale = currentLoadingModel.scale;
        modelFilter.sharedMesh = currentLoadingModel.model.GetComponent<MeshFilter>().sharedMesh;
        modelRenderer.sharedMaterials = currentLoadingModel.model.GetComponent<MeshRenderer>().sharedMaterials;
        title.text = currentLoadingModel.title;
        description.text = currentLoadingModel.description;
    }

    private IEnumerator LoadSceneAsync (string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            loadingImage.rectTransform.sizeDelta = new Vector2(operation.progress * 100 * 5, 50);

            if (operation.progress >= 0.9f)
            {
                loadingImage.rectTransform.sizeDelta = new Vector2(500, 50);
                loadingProgress.text = loadingDoneText;
                break;
            }

            yield return null;
        }

        yield return new WaitUntil(() => operation.progress >= 0.9f && Input.GetKey(KeyCode.Space));

        operation.allowSceneActivation = true;
    }

    private void SetRandomModel()
    {
        int index = Random.Range(0, modelList.Length);

        if (currentLoadingModel == modelList[index])
            if (index >= modelList.Length - 1)
                index = 0;
            else
                index++;

        currentLoadingModel = modelList[index];
    }
}
