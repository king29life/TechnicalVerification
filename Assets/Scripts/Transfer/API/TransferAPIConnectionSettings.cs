using System;
using UnityEngine;

namespace knomoto.TechnicalVerification.API
{
    /// <summary>
    /// APIの接続設定を定義します。
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Data/TransferAPIConnectionSettings", fileName = "TransferAPIConnectionSettings")]
    public sealed class TransferAPIConnectionSettings : ScriptableObject
    {
        /// <summary>
        /// GetSampleの接続文字列
        /// </summary>
        [SerializeField]
        private string m_GetSampleUri = "";

        /// <summary>
        /// GetSampleの接続文字列を取得します。
        /// </summary>
        public string GetSampleUri => m_GetSampleUri;
    }
}