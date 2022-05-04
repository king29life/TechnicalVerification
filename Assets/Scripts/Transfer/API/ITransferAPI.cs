using Cysharp.Threading.Tasks;

namespace knomoto.TechnicalVerification.API
{
    /// <summary>
    /// WebAPIのインタフェースを定義します。
    /// </summary>
    public interface ITransferAPI
    {
        UniTask GetSample();
    }
}