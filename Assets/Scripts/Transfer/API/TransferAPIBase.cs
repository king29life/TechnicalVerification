using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace knomoto.TechnicalVerification.API
{
    /// <summary>
    /// WebAPIの共通機能を提供するクラスです。
    /// </summary>
    public abstract class TransferAPIBase
    {
        /// <summary>
        /// GETリクエストを送信します。
        /// </summary>
        protected async UniTask<UnityWebRequest> Get(string uri, Dictionary<string, string> parameters)
        {
            var request = UnityWebRequest.Get(uri);
            return await SendRequest(request, parameters);
        }

        /// <summary>
        /// POSTリクエストを送信します。
        /// </summary>
        protected async UniTask<UnityWebRequest> Post(string uri, Dictionary<string, string> parameters, byte[] body)
        {
            var request = new UnityWebRequest(uri, "POST");
            if (body != null && body.Length > 0)
            {
                request.uploadHandler = new UploadHandlerRaw(body);
            }
            return await SendRequest(request, parameters);
        }

        /// <summary>
        /// リクエストを送信します。
        /// </summary>
        protected async UniTask<UnityWebRequest> SendRequest(UnityWebRequest request, Dictionary<string, string> parameters)
        {
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    request.SetRequestHeader(param.Key, param.Value);
                }
            }

            await request.SendWebRequest();

            if (request.responseCode != (long)HttpStatusCode.OK)
            {
                Debug.LogError($"{request.responseCode}:{request.error}");
            }

            return request;
        }
    }
}