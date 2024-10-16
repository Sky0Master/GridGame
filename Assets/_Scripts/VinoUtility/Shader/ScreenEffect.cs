using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways,ImageEffectAllowedInSceneView]
public class ScreenEffect : MonoBehaviour
{
    [SerializeField]
    Shader scShader;
    Material scMat;
    public int pixelNum = 100;
    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        ShaderHelper.InitMaterial(scShader,ref scMat);
        scMat.SetFloat("_PixelNum", pixelNum);
        Graphics.Blit(src, dest, scMat);
    }
}
