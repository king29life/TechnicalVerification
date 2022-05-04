using knomoto.TechnicalVerification.API;
using UnityEngine;

namespace knomoto.TechnicalVerification
{
    /// <summary>
    /// データに関する機能を提供します。
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class DataManager : MonoBehaviour
    {
        /// <summary>
        /// APIの接続情報
        /// </summary>
        [SerializeField]
        private TransferAPIConnectionSettings m_TransferServiceSettings = null;

        /// <summary>
        /// APIサービスを取得します。
        /// </summary>
        public ITransferAPI APIService { get; private set; }

        /// <summary>
        /// 初期化処理を実行します。
        /// </summary>
        public void Initialize()
        {
            APIService = new TransferAPIClient(m_TransferServiceSettings);
        }
    }
}