using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace knomoto.TechnicalVerification.API
{
    /// <summary>
    /// WebAPIの通信機能を提供します。
    /// 注記：HL2(UWP/IL2CPP)の環境下ではUnityWebRequestが動作しなかったためWindows.Web.Httpを使用
    /// </summary>
    public sealed class TransferAPIClient : TransferAPIBase, ITransferAPI
    {
        /// <summary>
        /// 接続情報を取得または設定します。
        /// </summary>
        private readonly TransferAPIConnectionSettings Settings;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TransferAPIClient(TransferAPIConnectionSettings settings)
        {
            Settings = settings;
        }

        public async UniTask GetSample()
        {
            var parameters = new Dictionary<string, string>()
            {
                
            };
            var response = await Get(Settings.GetSampleUri, parameters);
            Debug.Log(response.downloadHandler.text);
        }

    }
}