using System.Collections;
using System.Collections.Generic;
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

    private LoadingModel currentLoadingModel;

    private const float rotationSpeed = 0.125f;
    private const int timer = 5;
    private const string loadingDoneText = "Pressione [ESPAÇO] para continuar...";

    void Start()
    {
        StartCoroutine(ChangeCurrentModel());

        if(LoadingPersistence.nextScene != null)
            StartCoroutine(LoadSceneAsync(LoadingPersistence.nextScene));
    }

    void LateUpdate()
    {
        RotationUtil.IncrementalRotate(modelPos, Space.World, rotationSpeed, false, true, false);
    }

    private IEnumerator ChangeCurrentModel()
    {        
        SetRandomModel();

        modelPos.transform.localScale = currentLoadingModel.scale;
        modelFilter.sharedMesh = currentLoadingModel.model.GetComponent<MeshFilter>().sharedMesh;
        modelRenderer.sharedMaterials = currentLoadingModel.model.GetComponent<MeshRenderer>().sharedMaterials;
        title.text = currentLoadingModel.title;
        description.text = currentLoadingModel.description;

        yield return new WaitForSeconds(timer);

        StartCoroutine(ChangeCurrentModel());
    }

    private IEnumerator LoadSceneAsync (string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            loadingImage.fillAmount = operation.progress;

            if (operation.progress >= 0.9f)
            {
                loadingImage.fillAmount = 100;
                loadingProgress.text = loadingDoneText;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

    private void SetRandomModel()
    {
        int index = Random.Range(0, modelList.Length);

        currentLoadingModel = modelList[index];
    }
}
