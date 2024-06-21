using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    //����Ƽ�� ��� �޴� â, Assets �޴� ���� �ϴܿ� Build AssetBundles ��� �׸��� �߰�. �� �׸��� ������ �Ʒ��� �Լ��� ����ȴ�.(�������� �ƴ� ������ ����)
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";//���¹����� ���ϰ��.
        if (!Directory.Exists(assetBundleDirectory))        //�ش� ������ �ִ��� Ȯ���ϰ� ���ٸ� ���Ӱ� ����.
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        //��� ���¹����� ����. ��� �ɼ��� None �̸�, ����Ʈ�� ���¹��鿡 ���Ե� Prefab �� ����� �͵�(���׸��� ��)�� �Բ� ÷�εȴ�. ��ũ��Ʈ�� ����.(Ư��ó�� �䱸, �������� �����ϸ� �ȵ�)
        //None �ɼ��� ��� LZMA �����Ѵ�. ���� ���� �뷮�̳�, �ϳ��� ����ϱ� ���ؼ� ��� ������ Ǯ��߸� �Ѵ�. �ٿ� �Ŀ��� LZ4 �� ����ȴ�.(��� ������ Ǯ�� �ʰ� �Ϻθ� ��밡��)
        //UncompressedAssetBundle ������. ChunkBasedCompression LZ4 ����. ûũ ���� �������� �κи� ������ Ǯ�� ��� ����.
        //EditorUserBuildSettings.activeBuildTarget �� ���� ���� ������ �÷����� Ÿ������.
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}
