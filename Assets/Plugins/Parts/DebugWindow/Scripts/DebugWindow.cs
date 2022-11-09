using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace knomoto
{
    public class DebugWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI debugText = default;

        private ScrollRect scrollRect;

        private void Start()
        {
            // Cache references
            scrollRect = GetComponentInChildren<ScrollRect>();

            // Subscribe to log message events
            Application.logMessageReceived += HandleLog;

            // Set the starting text
            debugText.text = "Debug messages will appear here.\n\n";

            /// アプリスキーマを設定し、読み込んだURIを表示する
            /// 1.アプリスキーマを設定する
            ///     https://docs.unity3d.com/ja/2022.2/Manual/windowsstore-assocation-launching.html
            /// 2.QRテキストに「ApplicationScheme:hoge」を埋め込み、QR認識するとアプリが起動する
            ///     https://learn.microsoft.com/ja-jp/windows/uwp/launch-resume/launch-app-with-uri
            /// 3.アプリ起動後、Application.absoluteURLから「ApplicationScheme:hoge」の文字列が取得できる
            ///     https://docs.unity3d.com/ja/2021.3/ScriptReference/Application-absoluteURL.html
            Debug.Log($"Application.absoluteURL: {Application.absoluteURL}");
        }

        private void OnDestroy()
        {
            Application.logMessageReceived -= HandleLog;
        }

        private void HandleLog(string message, string stackTrace, LogType type)
        {
            // フィルター
            //if (type == LogType.Warning) return;
            debugText.text += message + " \n";
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0;
        }
    }
}