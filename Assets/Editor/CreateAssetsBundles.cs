using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    //유니티의 상단 메뉴 창, Assets 메뉴 가장 하단에 Build AssetBundles 라는 항목을 추가. 그 항목을 누르면 아래의 함수가 실행된다.(실행중이 아닌 에디터 편집)
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";//에셋번들의 파일경로.
        if (!Directory.Exists(assetBundleDirectory))        //해당 파일이 있는지 확인하고 없다면 새롭게 생성.
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        //모든 에셋번들을 빌드. 가운데 옵션이 None 이면, 디폴트로 에셋번들에 포함된 Prefab 과 연계된 것들(메테리얼 등)도 함께 첨부된다. 스크립트는 예외.(특수처리 요구, 기존에서 삭제하면 안됨)
        //None 옵션의 경우 LZMA 압축한다. 가장 작은 용량이나, 하나를 사용하기 위해서 모든 압축을 풀어야만 한다. 다운 후에는 LZ4 로 압축된다.(모든 압축을 풀지 않고 일부만 사용가능)
        //UncompressedAssetBundle 무압축. ChunkBasedCompression LZ4 압축. 청크 단위 압축으로 부분만 압축을 풀어 사용 가능.
        //EditorUserBuildSettings.activeBuildTarget 는 현재 빌드 설정된 플랫폼을 타겟으로.
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}
