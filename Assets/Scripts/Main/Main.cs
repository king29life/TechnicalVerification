using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace knomoto.TechnicalVerification
{
    /// <summary>
    /// プログラムのエントリーポイントを定義します。
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private DataManager m_DataManager = null;

        /// <summary>
        /// プログラムのエントリーポイントです。
        /// </summary>
        private async UniTask Start()
        {
            try
            {
                await InitializeAsync();
            }
            catch(Exception e)
            {
                Debug.Log(e.Message);
            }
            
        }

        /// <summary>
        /// 初期化処理を実行します。
        /// </summary>
        private async UniTask InitializeAsync()
        {
            // データに関する機能を初期化
            m_DataManager.Initialize();

            await m_DataManager.APIService.GetSample();
        }
    }
}