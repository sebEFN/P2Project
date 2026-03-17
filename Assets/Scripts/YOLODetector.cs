using UnityEngine;
using Unity.InferenceEngine;

public class YOLODetector : MonoBehaviour
{
    public ModelAsset modelAsset;
    private Worker worker;
    public Texture2D testTexture;

    void Start()
    {
        var model = ModelLoader.Load(modelAsset);
        worker = new Worker(model, BackendType.GPUCompute);
        Run(testTexture);
    }

    public void Run(Texture2D image)
    {
        Tensor input = TextureConverter.ToTensor(image, 640, 640, 3);

        worker.Schedule(input);

        Tensor output = worker.PeekOutput();

        Debug.Log(output.shape);
    }
    void Update()
    {
        
    }
    void OnDestroy()
    {
        worker?.Dispose();
    }
}