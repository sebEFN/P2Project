using UnityEngine;
using Unity.InferenceEngine;
using Unity.InferenceEngine.Layers;

public class YOLODetector : MonoBehaviour
{
    public ModelAsset modelAsset;
    private Model runtimeModel;
    private Worker worker;
   
    public Texture2D testTexture;

    private Tensor<float> inputTensor;

    [SerializeField] private float[] results;
    

    void Start()
    {
        runtimeModel = ModelLoader.Load(modelAsset);
        worker = new Worker(runtimeModel, BackendType.GPUCompute);

        ExecuteModel();
    }

    private void ExecuteModel()
    {
        inputTensor?.Dispose();
    inputTensor = TextureConverter.ToTensor(testTexture, 640, 640, 3);

    // Schedule the inference
    worker.Schedule(inputTensor);

    // Get output
    var outputTensor = worker.PeekOutput() as Tensor<float>;
    if (outputTensor == null)
    {
        Debug.LogError("Output tensor is null!");
        return;
    }

    // Clone to CPU so we can read values
    using var cpuTensor = outputTensor.ReadbackAndClone();

    // Example: read first 10 values
    for (int i = 0; i < 10 && i < cpuTensor.shape.length; i++)
    {
        Debug.Log($"Value {i}: {cpuTensor[i]}");
    }

    // Optionally store in results array
    results = new float[cpuTensor.shape.length];
    for (int i = 0; i < cpuTensor.shape.length; i++)
    {
        results[i] = cpuTensor[i];
    }

    // Dispose GPU tensor if needed
    outputTensor.Dispose();
}

    private void OnDisable()
    {
        inputTensor?.Dispose();
        worker.Dispose();
    }
}